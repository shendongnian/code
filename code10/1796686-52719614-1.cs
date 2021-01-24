    using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Web;
	using System.Web.UI;
	using System.Web.UI.WebControls;
	namespace tempApp13
	{
		public partial class WebForm1 : System.Web.UI.Page
		{
			protected void Page_Load(object sender, EventArgs e)
			{
				if (!IsPostBack)
				{
					gv.DataSource = new List<Employee>
					{
						new Employee { ID = 1, Name = "John", Job = "Clerk", Salary = 25000 },
						new Employee { ID = 2, Name = "Allen", Job = "Clerk", Salary = 20000 },
						new Employee { ID = 3, Name = "Smith", Job = "Sales", Salary = 21000 },
						new Employee { ID = 4, Name = "Martin", Job = "Sales", Salary = 35000 },
						new Employee { ID = 5, Name = "Bruce", Job = "Analyst", Salary = 35000 },
						new Employee { ID = 6, Name = "James", Job = "Clerk", Salary = 25000 },
					};
					gv.DataBind();
				}
			}
			protected void btnSubmit_Click(object sender, EventArgs e)
			{
				foreach (GridViewRow row in gv.Rows)
				{
					var chk = (CheckBox)row.FindControl("chkRemove");
					if (chk.Checked)
					{
						litMessage.Text += row.Cells[1].Text + " ";
					}
				}
			}
		}
		public class Employee
		{
			public int ID { get; set; }
			public string Name { get; set; }
			public string Job { get; set; }
			public int Salary { get; set; }
		}
	}
