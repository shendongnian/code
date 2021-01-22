    string pathIntern = @"\\11fil01\brukar\" + user.UserName;               
    DirectoryInfo diIntern       = new DirectoryInfo(pathIntern);
    DirectorySecurity dsecIntern = diIntern.GetAccessControl();
    IdentityReference newUser    = new NTAccount(domain + @”\” + username);
    dsecIntern.SetOwner(newUser);
    FileSystemAccessRule permissions = new FileSystemAccessRule(newUser,FileSystemRights.FullControl, AccessControlType.Allow);
    dsecIntern.AddAccessRule(permissions);
    diIntern.SetAccessControl(dsecIntern);
