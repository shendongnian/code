    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    namespace NS
    {
        public partial class WebForm1 : System.Web.UI.Page
        {
            protected string Btn1;
            protected void Page_Load(object sender, EventArgs e)
            {
                Btn1 = "hello";
                Page.DataBind();
            }
        }
    }
