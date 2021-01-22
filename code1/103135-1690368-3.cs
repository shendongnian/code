        protected void Page_Load(object sender, EventArgs e)
        {
            var allFormControls = new Dictionary<Control, string>();
            GetControls(this.Controls, allFormControls);
        }
        private static void GetControls(ControlCollection controlCollection, IDictionary<Control, string> allFormControls)
        {
            
                         
            foreach (Control control in controlCollection)
            {
                if (control is TextBox)
                    allFormControls.Add(control, ((TextBox) control).Text);
                GetControls(control.Controls, allFormControls);
            }
        }
