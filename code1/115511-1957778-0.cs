    public string DetectScheme(string address)
    {
        Uri result;
        if (Uri.TryCreate(address, UriKind.Absolute, out result))
        {
            // You can only get Scheme property on an absolute Uri
            return result.Scheme;
        }
    
        try
        {
            new FileInfo(address);
            return "file";
        }
        catch
        {
            throw new ArgumentException("Unknown scheme supplied", "address");
        }
    }
