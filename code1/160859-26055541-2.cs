    /// <summary>
    /// Tries to convert the specified string representation of a logical value to
    /// its type T equivalent. A return value indicates whether the conversion
    /// succeeded or failed.
    /// </summary>
    /// <typeparam name="T">The type to try and convert to.</typeparam>
    /// <param name="value">A string containing the value to try and convert.</param>
    /// <param name="result">If the conversion was successful, the converted value of type T.</param>
    /// <returns>If value was converted successfully, true; otherwise, false.</returns>
    public static bool TryParse<T>(string value, out T result) where T : struct {
        var tryParseMethod = typeof(T).GetMethod("TryParse", BindingFlags.Static | BindingFlags.Public, null, new [] { typeof(string), typeof(T).MakeByRefType() }, null);
        var parameters = new object[] { value, null };
        var retVal = (bool)tryParseMethod.Invoke(null, parameters);
        result = (T)parameters[1];
        return retVal;
    }
    /// <summary>
    /// Tries to convert the specified string representation of a logical value to
    /// its type T equivalent. A return value indicates whether the conversion
    /// succeeded or failed.
    /// </summary>
    /// <typeparam name="T">The type to try and convert to.</typeparam>
    /// <param name="value">A string containing the value to try and convert.</param>
    /// <returns>If value was converted successfully, true; otherwise, false.</returns>
    public static bool TryParse<T>(string value) where T : struct {
        T throwaway;
        var retVal = TryParse(value, out throwaway);
        return retVal;
    }
