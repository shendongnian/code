    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using AjaxControlToolkit;
    
    namespace WebApplication2
    {
        public partial class _Default : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                CalendarExtender myCalExt = new CalendarExtender();
                myCalExt.TargetControlID = "TextBox1";
                Place1.Controls.Add(myCalExt);
            }
        }
    }
