    private void genPassMenu_Opening(object sender, CancelEventArgs e)
        {
            //genPassMenu.Enabled = lstPasswords.SelectedIndex > 0;
            //genPassMenu.Visible = lstPasswords.SelectedIndex > 0;
            e.Cancel = (lstPasswords.SelectedIndex <= 0);
        }
