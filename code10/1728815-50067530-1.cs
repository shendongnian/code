    using System;
    using System.Collections.Generic;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    namespace TestRepeater
    {
        public partial class Test : Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!Page.IsPostBack)
                {
                    // Force the creation of three repeater items.
                    repeater.DataSource = new List<string>() { "", "", "" };
                    repeater.DataBind();
                }
            }
    
            protected void TextBox_TextChanged(object sender, EventArgs e)
            {
                TextBox textBox = (TextBox)sender;
    
                Label label = (Label)textBox.Parent.FindControl("TheLabel");
    
                label.Text = "Hello, world!";
            }
        }
    }
