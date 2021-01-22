    class SomeForm: Form
    {
        public string MyTextField
        {
            get { return txtMyField.Text; } // Gets the Text value of a control named txtMyField on this form
        }
    }
    
    // ...
    
    var form = new SomeForm();
    if (form.ShowDialog(this) == DialogResult.Ok)
    {
        string data = form.MyTextField;
    }
