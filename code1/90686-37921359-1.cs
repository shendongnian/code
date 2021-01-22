    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    namespace TestProject
    {
        public partial class WebForm3 : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                SampleDataContext context = new SampleDataContext();
                List<Employee> l = new List<Employee>();
                var qry = from a in context.tbl_employees where a.Gender=="Female"  
                    orderby  a.Salary ascending
                select new Employee() {
                               ID=a.Id,
                               Fname=a.FName,
                               Lname=a.Lname,
                               Gender=a.Gender,
                               Salary=a.Salary,
                               DepartmentId=a.DeparmentId
                };
                l= qry.ToList();
                var e1 =  from  emp in context.tbl_employees
                    where emp.Gender == "Male"
                    orderby emp.Salary descending
                    select  emp;
                GridView1.DataSource = l;
                GridView1.DataBind();
            }
        }
        public class Employee
        {
            public Int64 ID { get; set; }
            public String Fname { get; set; }
            public String Lname { get; set; }
            public String Gender { get; set; }
            public decimal? Salary { get; set; }
            public int? DepartmentId { get; set; }
        }
    }
