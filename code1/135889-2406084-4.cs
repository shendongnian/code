    public IEnumerable<string> GetHashStrings(string fileName,
        params Type[] algorithmTypes)
    {
        if (algorithmTypes == null)
            return Enumerable.Empty<string>();
        byte[] fileBytes = File.ReadAllBytes(fileName);
        return algorithmTypes
            .Where(t => t.IsSubclassOf(typeof(HashAlgorithm)))
            .Select(t => (HashAlgorithm)Activator.CreateInstance(t))
            .Select(a => a.ComputeHash(fileBytes))
            .Select(b => HexStr(b));
    }
