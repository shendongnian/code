    ListArray<string> settingsRead = new ListArray<string>();
    using (var sr = new StreamReader(myFile))
    {
        string line;
        while ((line = sr.ReadLine()) != null)
        {
            string[] keyValueStrings = line.Split(separator);
            for (int i = 0; i < keyValueStrings.Length; i++)
                keyValueStrings[i] = keyValueStrings[i].Trim();
            settingsRead.Add(keyValueStrings);
        }
    }
    // Later you get your key/value strings simply by index
    string[] myKeyValueStrings = settingsRead[index];
