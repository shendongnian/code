    public override void Install(IDictionary stateSaver)
    {
        .... open the form, bla bla bla
        serviceProcessInstaller.Password = accountForm.txtPassword.Text;
        Context.Parameters["USERNAME"] = accountForm.txtPassword.Text;
        serviceProcessInstaller.Username = accountForm.txtServiceAccount.Text;
        Context.Parameters["PASSWORD"] = accountForm.txtServiceAccount.Text;
        serviceProcessInstaller.Account = ServiceAccount.User;
    }
