    string name;
    Configuration config = new Configuration();
    if (dict.TryGetValue("Name", out name))
    {
        config.Name = name;
    }
    else
    {
        throw new ArgumentException("'Name' was not present.");
    }
