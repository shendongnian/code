    options.CredentialsProvider = (url, usernameFromUrl, types) => {
        string username, password;
        Uri uri = new Uri(url);   
        string hostname = uri.Host;
        ProcessStartInfo startInfo = new ProcessStartInfo();
        startInfo.UseShellExecute = false;
        
        startInfo.RedirectStandardInput = true;
        startInfo.RedirectStandardOutput = true;
        startInfo.RedirectStandardError = true;
        startInfo.FileName = "git.exe";
        startInfo.Arguments = "credential fill";
        Process process = new Process();
        process.StartInfo = startInfo;
        process.Start();
        process.StandardInput.WriteLine("hostname={0}", hostname);
        process.StandardInput.WriteLine("username={0}", usernameFromUrl);
        while ((line = process.StandardOutput.ReadLine()) != null)
        {
            string[] details = line.Split('=', 2);
            if (details[0] == "username")
            {
                username = details[1];
            }
            else if (details[0] == "password")
            {
                password = details[1];
            }
        }
        return new UsernamePasswordCredentials(username, password);
    };
