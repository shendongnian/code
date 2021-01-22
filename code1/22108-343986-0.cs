    Dictionary<string,long> dictionary = new Dictionary<string,long>();
    using (TextReader reader = File.OpenText(filename))
    {
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            string[] bits = line.Split('=');
            // Error checking would go here
            long value = long.Parse(bits[1]);
            dictionary[bits[0]] = value;
        }
    }
