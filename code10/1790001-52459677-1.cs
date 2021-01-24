    private void checkBox1_Checked(object sender, EventArgs e)
    {
        var mainForm = Application.OpenForms.OfType<MainForm>().FirstOrDefault();
        if(mainForm != null)
        {
            this.TopMost = !checkBox1.Checked;
            mainForm.TopMost = checkBox1.Checked;
        }
    }
