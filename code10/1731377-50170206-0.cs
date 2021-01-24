    private void btnSave_Click(object sender, EventArgs e)
    {
        if (NotERROR)
        {
            DoSomething();
            DialogResult = DialogResult.OK;
        } 
        else 
        {
            MessageBox.Show("ERROR");
        }
    }
