    var assembly = IntrospectionExtensions.GetTypeInfo(typeof(LoginPage)).Assembly;
    Stream stream = assembly.GetManifestResourceStream("YourAssembly.Logins.txt");
    string text = "";
    using (var reader = new System.IO.StreamReader (stream)) 
    {
        text = reader.ReadToEnd ();
    }
