    using System;
    using System.Collections.Generic;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    namespace GridViewEventHandling
    {
        public partial class _Default : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                myControl.OnLinkClick += new EventHandler(myControl_OnLinkClick);
            }
    
            private void myControl_OnLinkClick(object sender, EventArgs e)
            {
                uxGridView.DataSource = GetDataSource();
                uxGridView.DataBind();
            }
    
            private IDictionary<string, string> GetDataSource()
            {
                IDictionary<string, string> dict = new Dictionary<string, string>();
                dict.Add("Product 1", "Description 1");
                dict.Add("Product 2", "Description 2");
                dict.Add("Product 3", "Description 3");
                return dict;
            }
    
    
        }
    }
