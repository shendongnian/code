    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    namespace DynamicApp
    {
        public partial class Default : System.Web.UI.Page
        {
            // data source
            List<string> dataTypeList = new List<string> { "text", "date", "number" };
            protected void Page_Load(object sender, EventArgs e)
            {     
                // creating dynamic textboxes
                var textBoxHolder = (HtmlGenericControl)mainForm.FindControl("textBoxHolder");
                var index = 1;
                foreach (var item in dataTypeList)
                {
                    var textBox = new TextBox();
                    textBox.ID = "txtBox" + (index++);
                    textBox.Attributes["type"] = item;
                    textBoxHolder.Controls.Add(textBox);
                }
            }
        
            protected void btnShow_Click(object sender, EventArgs e)
            {
                // getting textbox values
                var textBoxHolder = (HtmlGenericControl)mainForm.FindControl("textBoxHolder");
                for (int index = 1; index <= dataTypeList.Count; index++)
                {
                    var textBox = (TextBox)textBoxHolder.FindControl("txtBox" + (index));
                    litShow.Text += textBox.Text + "<br>";
                }
            }
        }
    }
