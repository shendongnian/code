    string newPassword = Membership.GeneratePassword(12, 4);    
    string quotePwd = String.Format(@"""{0}""", newPassword);    
    byte[] pwdBin = System.Text.Encoding.Unicode.GetBytes(quotePwd);    
    UserEntry.Properties["unicodePwd"].Value = pwdBin;    
    UserEntry.CommitChanges();
