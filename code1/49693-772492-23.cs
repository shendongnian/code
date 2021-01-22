    static bool HasJpegExtension(string filename)
    {
        // add other possible extensions here
        return Path.GetExtension(filename).Equals(".jpg", StringComparison.InvariantCultureIgnoreCase)
            || Path.GetExtension(filename).Equals(".jpeg", StringComparison.InvariantCultureIgnoreCase);
    }
