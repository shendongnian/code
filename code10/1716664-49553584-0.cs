    private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        using (FrmAddMov frmAddMov = new FrmAddMov())
        {
            if (frmAddMov.ShowDialog() == DialogResult.OK)
            {
               FormLoad();
            }
        }
    }
