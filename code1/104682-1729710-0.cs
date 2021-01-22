    class MyControl : UserControl
    {
        private DropDownForm form = new DropDownForm();
        public MyControl()
        {
            form.FormClosed += dropdownform_closed;
        }
        private void MethodThatShowsDropdown()
        {
            form.AddData(GetTheData());
            form.Show(this.Owner); // Or is it "this.Parent"?  I can never remember...
        }
        private void dropdownform_closed(object sender, EventArgs e)
        {
            DoSomething(form.SelectedValue);
        }
    }
