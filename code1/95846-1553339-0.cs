    string UserInfoPath = ConfigurationManager.AppSettings["UserInfo"];
    if (String.IsNullOrEmpty(UserInfoPath))
    {
        // perhaps use a default value or raise an exception
    }
    FileInfo fileusername = new FileInfo(Path.Combine(Application.StartUpPath, UserInfoPath));
    StreamWriter namewriter = fileusername.CreateText();
    namewriter.Write(txtUsername.Text);
    namewriter.Close();
