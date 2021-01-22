    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    namespace Demo
    {
        public partial class WebForm1 : System.Web.UI.Page
        {
            public char[] splitChars = new char[] { ' '};
            protected void Page_Load(object sender, EventArgs e)
            {
                dataGrid1.DataSource = new List<dynamic>() { new { id = 1, names = "one single" }, new { id = 2, names = "two double" } };
                dataGrid1.DataBind();
            }
    
        }
    }
