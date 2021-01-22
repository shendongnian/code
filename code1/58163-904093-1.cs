    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Linq;
    using System.Web;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using System.Web.UI.WebControls.WebParts;
    using System.Xml.Linq;
    
    namespace WebApplication1
    {
        public partial class _Default : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                List<string> list = new List<string>();
                list.Add("Some");
                list.Add("Other");
    
                FormView1.DataSource = list; //just to get the formview going
    
                FormView1.DataBind(); 
    
            }
    
            protected void FormView1_DataBound(object sender, EventArgs e)
            {
                DropDownList ddl = null;
                if(FormView1.Row != null)
                    ddl = (DropDownList) FormView1.Row.FindControl("DropDownList1");
                ddl.SelectedIndex = ddl.Items.IndexOf(ddl.Items.FindByValue("Two"));
            }
    
        }
    }
