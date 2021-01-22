    using System;
    using System.Web.UI.WebControls;
    
    namespace WebApplication1
    {
        public partial class _Default : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                // Add any controls that have been previously added dynamically
                for (int i = 0; i < TotalNumberAdded; ++i)
                {
                    AddControls(i + 1);
                }
    
                // Attach the event handler to the button
                Button1.Click += new EventHandler(Button1_Click);
            }
    
            void Button1_Click(object sender, EventArgs e)
            {
                // Increase the number added and add the new label and textbox
                TotalNumberAdded++;
                AddControls(TotalNumberAdded);
            }
    
            private void AddControls(int controlNumber)
            {
                var newPanel = new Panel();
                var newLabel = new Label();
                var newTextbox = new TextBox();
    
                // textbox needs a unique id to maintain state information
                newTextbox.ID = "TextBox_" + controlNumber;
    
                newLabel.Text = "New Label";
    
                // add the label and textbox to the panel, then add the panel to the form
                newPanel.Controls.Add(newLabel);
                newPanel.Controls.Add(newTextbox);
                form1.Controls.Add(newPanel);
            }
    
            protected int TotalNumberAdded
            {
                get { return (int)(ViewState["TotalNumberAdded"] ?? 0); }
                set { ViewState["TotalNumberAdded"] = value; }
            }
    
        }
    }
