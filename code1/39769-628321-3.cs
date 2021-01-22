    using System;
    using System.Data;
    using System.Configuration;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Web.UI.WebControls.WebParts;
    using System.Web.UI.HtmlControls;
    
    namespace CheckboxMadness
    {
        public partial class _Default : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                List<string> statements = new List<string>(new string[] { "foo", "bar" });
    
                foreach (string i in statements)
                {
                    CheckBox box = new CheckBox();
                    box.Text = i;
                    box.AutoPostBack = true;
                    box.CheckedChanged += new EventHandler(this.CheckedChange);
                    PlaceHolder1.Controls.Add(box);
                }
                           
            }
            protected void CheckedChange(object sender, EventArgs e)
            {
                CheckBox x = (CheckBox)sender;
    
                Instructions.Text = "change";
    
                WorkPlaceHazardsBox.Text += x.Text;
            }
        }
    }
