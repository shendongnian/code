    string[] sAryArg = null;
    L.g(() =>/**/sAryArg = Environment.GetCommandLineArgs()/**/);
    L.g(() =>/**/this.lblUserName.Text = sAryArg[3]/**/);
    L.g(() =>/**/this.lblDatabase.Text = DbUtil._sEnvID_/**/);
    L.g(() =>/**/this.lblVersion.Text =
        Assembly.GetExecutingAssembly().GetName().Version.Major.ToString() + "." +
        Assembly.GetExecutingAssembly().GetName().Version.Minor.ToString() + "." +
        Assembly.GetExecutingAssembly().GetName().Version.Build.ToString()/**/);
