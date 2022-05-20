using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace WebApplication1.Models
{
    public class EmpDataAccess

    {
        string connectionString = "Data Source=DESKTOP-B0EREMN; Initial Catalog=cohort21; Integrated Security = True;";
        public IEnumerable<Employee> GetAllEmp()
        {
            List<Employee> empList = new List<Employee>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("getEmploye", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    Employee employee = new Employee();
                    employee.EmployeID = Convert.ToInt32(sdr["EmployeID"]);
                    employee.EmployeName = sdr["EmployeName"].ToString();                
                    employee.EmployeDept = sdr["EmployeDept"].ToString();              
                    empList.Add(employee);
                }
                con.Close();
            }
            return empList;
            }
        }
    }

