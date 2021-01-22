    public bool IsPathValidRootedLocal(String pathString)
    {
        Uri pathUri;
        return Uri.TryCreate(pathString, UriKind.Absolute, out pathUri)
            && pathUri.IsLoopback;
    }
