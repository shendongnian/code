    string[] AllStrings;
    using (var Reader = new ResXResourceReader(fileName))
    {
        AllStrings = Reader.Cast<DictionaryEntry>().Select(o => o.Value).OfType<string>().ToArray();
    }
