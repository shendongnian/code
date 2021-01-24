    public void create(string lanid, string new_password, string container)
        {
            using (UserPrincipal new_user = new UserPrincipal(new PrincipalContext(ContextType.Domain, this.domain_string, container)))
            {
                new_user.SamAccountName = lanid;
                new_user.SetPassword(new_password);
                new_user.Enabled = true;
                new_user.Save();
            }
        }
