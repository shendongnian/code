    public Startup(IHostingEnvironment env)
    {
        /* skipping boilerplate setup code */
        
        Environment = env;
    }
    
    private IHostingEnvironment Environment { get; set; }
    private void ConfigureDataProtection(IServiceCollection services) {
        // get the file from the Keys directory
        string keysFile = string.Empty;
        string keysPath = Path.Combine(Environment.ContentRootPath, "Keys");
        if (!Directory.Exists(keysPath)) {
            Log.Add($"Keys directory {keysPath} doesn't exist");
            return;
        }
        string[] files = Directory.GetFiles(keysPath);
        if (files.Length == 0) {
            LLog.Add($"No keys found in directory {keysPath}");
            return;
        } else {
            keysFile = files[0];
            if (files.Length >= 2) {
                LLog.Add($"Warning: More than 1 key found in directory {keysPath}.  Using first one.");
            }
        }
        // find and optionally create the path for the key storage
        var appDataPath = Path.Combine(
            System.Environment.GetFolderPath(System.Environment.SpecialFolder.CommonApplicationData),
            "companyName",
            "productName"
        );
        if (!Directory.Exists(appDataPath)) {
            try {
                Directory.CreateDirectory(appDataPath);
            } catch (Exception ex) {
                Log.Add($"Error creating key storage folder at {appDataPath}.  Error: {ex.Message}");
                return;
            }
        }
        // delete any keys from the storage directory
        try {
            foreach (var file in new DirectoryInfo(appDataPath).GetFiles()) file.Delete();
        } catch (Exception ex) {
            Log.Add($"Error deleting keys from {appDataPath}.  Error: {ex.Message}");
            return;
        }
        try {
            string targetPath = Path.Combine(appDataPath, new FileInfo(keysFile).Name);
            File.Copy(keysFile, targetPath, true);
        } catch (Exception ex) {
            Log.Add($"Error copying key file {keysFile} to {appDataPath}.  Error: {ex.Message}");
            return;
        }
        // everything is in place
        services.AddDataProtection()
            .PersistKeysToFileSystem(new DirectoryInfo(appDataPath))
            .DisableAutomaticKeyGeneration();
    }
