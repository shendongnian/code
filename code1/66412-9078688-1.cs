        ProcessStartInfo info = new ProcessStartInfo("D:\\My\\notepad.exe");
        info.UseShellExecute = false;
        info.RedirectStandardInput = true;
        info.RedirectStandardError = true;
        info.RedirectStandardOutput = true;
        //info.UserName = dialog.User;   
        info.UserName = "xyz";
        string pass = "xyz";
        System.Security.SecureString secret = new System.Security.SecureString();
        foreach (char c in pass)
            secret.AppendChar(c);
        info.Password = secret;
        using (Process install = Process.Start(info))
        {
            string output = install.StandardOutput.ReadToEnd();
            install.WaitForExit();
            // Do something with you output data          
            Console.WriteLine(output);
        }
