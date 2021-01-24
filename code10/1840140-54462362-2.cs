    Dictionary<string, List<string>> countrycitydict{ get; }
    public Dictionary<string, List<string>> ReadFile(string path)
    {
        using (var reader = new StreamReader(path))
        {
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (line != "Country;City")
                {
                    var values = line.Split(';');
                    // Try to get the entry for the current country
                    if(!countrycitydict.TryGetValue(values[0], out List<string> v))
                    {
                        // If not found build an entry for the country
                        List<string> cities = new List<string>()
                        countrycitydict.Add(values[0], cities) ;
                    }
                    // Now you can safely add the city
                    countrycitydict[values[0]].Add(values[1]);
                }
           }
           return countrycitydict;
       }
    }
