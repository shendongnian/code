    /// <summary>
    /// Checks to see if the specified value is a double.
    /// </summary>
    /// <param name="valueToCheck">The value to check.</param>
    /// <exception cref="ArgumentException">If <paramref name="valueToCheck"/>
    /// is null or empty.</exception>
    /// <exception cref="DataFormatException">If <paramref name="valueToCheck"/>
    /// could not be parsed as a valid double.</exception>
    private static double CheckDouble(string valueToCheck)
    {
        if (string.IsNullOrEmpty(valueToCheck))
            throw new ArgumentException("Argument 'valueToCheck' cannot be null or empty.", "valueToCheck");
    
        double result;
    
        if (double.TryParse(valueToCheck, out result))
        {
            return result;
        }
    
        throw new DataFormatException("Value '" + valueToCheck + "' could not be parsed as a double.");
    }
