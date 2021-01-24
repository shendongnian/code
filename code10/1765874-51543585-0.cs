    public class Ribbon
    {
        private void btnSpltData_Click(object sender, RibbonControlEventArgs e)
        {
            FieldSelector fs = new FieldSelector();
            fs.ShowDialog();
            if (fs.DialogResult == DialogResult.OK) // Did user press the 'done' button? or did they exit using X
            {
                foreach (var checkedField in fs.CheckedFields)
                {
                    // do stuff with the value
                }
            }
        }
    }
    public class FieldSelector :  Form
    {
        // A property to read after the form has closed
        public List<string> CheckedFields 
        { 
             get; 
        } = new List<string>(); // Never null
        private void buttonDone_Click(object sender, EventArgs e)
        {
            // Retrieve all the Checkboxes that are a direct child of the form
            foreach (var control in Controls.OfType<CheckBox>())
            {
                if (control.Checked)
                    CheckedFields.Add(control.Text); // Keep track of the Text value of the checked checkboxes
            }
            this.DialogResult = DialogResult.OK; // just for being neat when using ShowDialog()
            this.Close();
        }
    }
