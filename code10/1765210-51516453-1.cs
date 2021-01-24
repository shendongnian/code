    private void chk_AdvancedMode_CheckedChanged(object sender, EventArgs e)
    {
        if (chk_AdvancedMode.Checked)
        {
            frmPassword frm_Password = new frmPassword();
            frm_Password.ShowModal();
            if(frm_Password.IsValidated)
            {
                BasicAdvancedMode(true);
                prop_RunningMode = "Running in Advanced Mode";
            }
        }
    }
