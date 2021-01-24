public void PushLibGit2Sharp(string repositoryFolder, string branch)
{
    using (var repo = new Repository(repositoryFolder))
    {
        var options = new PushOptions
        {
            CredentialsProvider = (url, usernameFromUrl, types) =>
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "git.exe",
                    Arguments = "credential fill",
                    UseShellExecute = false,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    CreateNoWindow = true,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                };
                Process process = new Process
                {
                    StartInfo = startInfo
                };
                process.Start();
                // Write query to stdin. 
                // For stdin to work we need to send \n instead of WriteLine
                // We need to send empty line at the end
                var uri = new Uri(url);
                process.StandardInput.NewLine = "\n";       
                process.StandardInput.WriteLine($"protocol={uri.Scheme}");
                process.StandardInput.WriteLine($"host={uri.Host}");
                process.StandardInput.WriteLine($"path={uri.AbsolutePath}");
                process.StandardInput.WriteLine();
                // Get user/pass from stdout
                string username = null;
                string password = null;
                string line;
                while ((line = process.StandardOutput.ReadLine()) != null)
                {
                    string[] details = line.Split('=');
                    if (details[0] == "username")
                    {
                        username = details[1];
                    }
                    else if (details[0] == "password")
                    {
                        password = details[1];
                    }
                }
                return new UsernamePasswordCredentials()
                {
                    Username = username,
                    Password = password
                };
            }
        };
        repo.Network.Push(repo.Branches[branch], options);
    }
}
