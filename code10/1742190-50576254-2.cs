	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Linq;
	using System.Web;
	using System.Web.UI;
	using System.Web.UI.WebControls;
	using WebApplication3.Models;
	namespace WebApplication3
	{
		public partial class Default : System.Web.UI.Page
		{
			protected void Page_Load(object sender, EventArgs e)
			{
				Calculations.Add(new int[3] { 1, 2, 3 });
				Calculations.Subtract(new int[3] { 1, 2, 3 });
				Calculations.Divide(new int[3] { 1, 2, 3 });
				Calculations.Multiply(new int[3] { 1, 2, 3 });
			}
		}
	}
