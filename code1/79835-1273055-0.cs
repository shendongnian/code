    public void Load(AddonCollection<T> collection)
    {
        // read from file
        var query =
            from line in LineReader(_LstFilename)
            where line.Length > 0
            select CreateAddon(line);
        // add results to collection
        collection.AddRange(query);
    }
    protected T CreateAddon(String line)
    {
        // create addon
        T addon = new T();
        addon.Load(line, _BaseDir);
        return addon;
    }
    protected static IEnumerable<String> LineReader(String fileName)
    {
        String line;
        using (var file = System.IO.File.OpenText(fileName))
        {
            // read each line, ensuring not null (EOF)
            while ((line = file.ReadLine()) != null)
            {
                // return trimmed line
                yield return line.Trim();
            }
        }
    }
