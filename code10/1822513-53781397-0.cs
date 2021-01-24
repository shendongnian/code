    [DirectoryProperty("extensionAttribute4")]
    public string ExtensionAttribute4
    {
        get
        {
            var extensionAttribute4 = ExtensionGet("extensionAttribute4");
            if (extensionAttribute4 == null || extensionAttribute4.Length != 1)
                return string.Empty;
            return (string)extensionAttribute4[0];
        }
        set { ExtensionSet("extensionAttribute4", value); }
    }
