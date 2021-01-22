    /// <summary>
    /// Checks if the provided object is equal to the current Person
    /// </summary>
    /// <param name="obj">Object to compare to the current Person</param>
    /// <returns>True if equal, false if not</returns>
    public override bool Equals(object obj)
    {        
        // Try to cast the object to compare to to be a Person
        var person = obj as Person;
        return Equals(person);
    }
    /// <summary>
    /// Returns an identifier for this instance
    /// </summary>
    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }
    /// <summary>
    /// Checks if the provided Person is equal to the current Person
    /// </summary>
    /// <param name="personToCompareTo">Person to compare to the current person</param>
    /// <returns>True if equal, false if not</returns>
    public bool Equals(Person personToCompareTo)
    {
        // Check if person is being compared to a non person. In that case always return false.
        if (personToCompareTo == null) return false;
        // If the person to compare to does not have a Name assigned yet, we can't define if it's the same. Return false.
        if (string.IsNullOrEmpty(personToCompareTo.Name) return false;
        // Check if both person objects contain the same Name. In that case they're assumed equal.
        return Name.Equals(personToCompareTo.Name);
    }
