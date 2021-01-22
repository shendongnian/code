    public string GetUserHome() {
        var homeDrive = Environment.GetEnvironmentVariable("HOMEDRIVE");
        if (!string.IsNullOrWhiteSpace(homeDrive))
        {
            var homePath = Environment.GetEnvironmentVariable("HOMEPATH");
            if (!string.IsNullOrWhiteSpace(homePath))
            {            
                var fullHomePath = homeDrive + Path.DirectorySeparatorChar + homePath;
                return Path.Combine(fullHomePath, "myFolder");
            }
            else
            {
                throw new Exception("Environment variable error, there is no 'HOMEPATH'");
            }
        }
        else
        {
            throw new Exception("Environment variable error, there is no 'HOMEDRIVE'");
        }
    }
