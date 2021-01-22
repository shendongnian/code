    /// <summary>
    /// Method return a read-only collection of the names of the constants in specified enum
    /// </summary>
    /// <returns></returns>
    public static ReadOnlyCollection<string> GetNames()
    {
        return Enum.GetNames(typeof(T)).Cast<string>().ToList().AsReadOnly();   
    }
