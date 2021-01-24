    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    public partial class Default2 : System.Web.UI.Page
    {
        int cnt = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(ViewState["QuickSearchText"] != null)
            {
                Label1.Text = ViewState["QuickSearchText"].ToString();
            }
            else
            {
                Label1.Text = "No viewstate set";
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            cnt++;
            ViewState["QuickSearchText"] = cnt.ToString();
        }
    }
