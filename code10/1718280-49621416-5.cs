    private static void Main() {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        var hasCredentialFile = CheckCredentialFile();        
        Application.Run(hasCredentialFile ? new Agent():Login());
    }
