    public partial class _Default : Page
    {
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            AddButtons();
        }
        protected void AddButtons()
        {
            AddButtonControl("btn1", "1");
            AddButtonControl("btn2", "2");
            AddButtonControl("btn3", "3");
        }
        protected void AddButtonControl(string id, string text)
        {
            var button = new Button { Text = text, ID = id };
            button.Click += button_Click;
            ButtonsPanel.Controls.Add(button);
        }
        private void button_Click(object sender, EventArgs e)
        {
            foreach (Control control in ButtonsPanel.Controls)
                control.Visible = !control.Equals(sender);
        }
    }
