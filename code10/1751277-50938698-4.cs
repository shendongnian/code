    public LoginPage()
    {
        InitializeComponent();
        // Read in the content of the embedded resource, but let's read 
        // each line to make processing a little easier
        var assembly = IntrospectionExtensions.GetTypeInfo(typeof(LoginPage)).Assembly;
        Stream stream = assembly.GetManifestResourceStream("YourAssembly.Logins.txt");
        var textLines = new List<string>();
        string line = null;
        using (var reader = new System.IO.StreamReader (stream)) 
        {
            while ((line = sr.ReadLine()) != null) 
            {
                textLines.Add(line);
            }
        }
        // Init our cred list
        this.CredentialList = new List<UserCredentials>();
        // Read out the contents of the username/password combinations
        foreach (var line in textLines)
        {
            // Grab items within new lines separated by a space and chuck them into their array
            string[] components = line.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            
            // Add the combination to our list
            this.CredentialList.Add(new UserCredential 
            {
                Username = user.Add(components[0]),
                Password = pass.Add(components[0])
            });
        }
    }
