    public static IEnumerable<T> EnumToList<T>()
        where T : struct
    {
        return Enum.GetValues(typeof(T)).Cast<T>();
    }
    // Using above method
    statesComboBox.Items = EnumToList<States>();
    // Inline
    statesComboBox.Items = Enum.GetValues(typeof(States)).Cast<States>();
    
