       protected void Page_Load(object sender, EventArgs e)
        {
            IList<Control> allFormControls = new List<Control>();
            GetControls(this.Controls, allFormControls);
        }
        private static void GetControls(ControlCollection controlCollection, ICollection<Control> allFormControls)
        {
            foreach (Control control in controlCollection)
            {
                if (control is TextBox || control is Button)
                    allFormControls.Add(control);
                GetControls(control.Controls, allFormControls);
            }
        }
