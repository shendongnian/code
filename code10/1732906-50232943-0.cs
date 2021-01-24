    string MyName = "David";
    string Sensentence = "Find my name";
    if (File.Exists("[SomeFilePath]"))
    {
        string[] AllNames = File.ReadAllLines("names.txt")
                                .Select(name => {
                                    return (name == MyName)
                                                 ? Sensentence + Environment.NewLine + name
                                                 : name;
                                }).ToArray();
        if (AllNames.Count() > 0)
            File.WriteAllLines("[SomeFilePath]", AllNames);
    }
