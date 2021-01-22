    public static string Domain
    {
        get
        {
            return _domain = AlwaysReadFromFile
                ? CredentialReader.Read(DOMAIN_TAG)
                : _domain ?? CredentialReader.Read(DOMAIN_TAG);
        }
    }
