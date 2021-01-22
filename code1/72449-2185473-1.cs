    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            qfh.User user = null;
            user = new qfh.User();
            user.UserName = txtUserName.Text;
            user.Name = txtName.Text;
            user.IsAdministrator = cboIsAdministrador.SelectedValue == "Yes";
            user.IsActive = cboIsActive.SelectedValue == "Yes";
            user.SaveCopy();
        }
        catch (Exception ex)
        {
            ex = Utilities.GetInnerException(ex);
            JSLiteral.Text = Utilities.GetFormattedExceptionMessage(ex);
        }
    }
