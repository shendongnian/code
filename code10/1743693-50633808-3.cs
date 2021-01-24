    using System;
    using System.Collections.Generic;
    using System.Web.UI.WebControls;
    
    namespace ButtonTest
    {
        public partial class ButtonTest : System.Web.UI.Page
        {
            static List<Button> buttons = new List<Button>();
            static bool allowItToWork = true;
            protected override void OnInit(EventArgs e)
            {
                if(Page.IsPostBack && allowItToWork)
                {
                    foreach (var button in buttons)
                    {
                        button.Click += ButtonAddClick; // Comment me out and added button's will do nothing when clicked.
                        ButtonPanel.Controls.Add(button);
                    }
                }
            }
    
            protected void ButtonAddClick(object sender, EventArgs e)
            {
                var button = new Button();
                button.Click += ButtonAddClick;
                button.Text = "Click Me Too";
                buttons.Add(button);
                ButtonPanel.Controls.Add(button);
            }
        }
    }
