    /// <summary>
    /// Compares two character enumerables one character at a time, ignoring those specified.
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="ignoreThese"> If not specified, the default is to ignore linefeed and newline: {'\r', '\n'} </param>
    /// <returns></returns>
    public static bool EqualsIgnoreSome(this IEnumerable<char> x, IEnumerable<char> y, params char[] ignoreThese)
    {
        // First deal with quickly handlable cases quickly:
        // Same instance - generally happens often in real code, and is a fast check, so always worth doing first.
        if (ReferenceEquals(x, y))
            return true;         //
        // We already know they aren't both null as ReferenceEquals(null, null) returns true.
        if (x == null || y == null)
            return false;
        // Default ignore is newlines:
        if (ignoreThese == null || ignoreThese.Length == 0)
            ignoreThese = new char[] { '\r', '\n' };
        // Filters by specifying enumerator.
        IEnumerator<char> eX = x.Where(c => !ignoreThese.Contains(c)).GetEnumerator();
        IEnumerator<char> eY = y.Where(c => !ignoreThese.Contains(c)).GetEnumerator();
        // Compares.
        while (eX.MoveNext())
        {
            if (!eY.MoveNext()) //y is shorter
                return false;
            if (eX.Current != eY.Current)
                return false;
        }
        return !eY.MoveNext(); //check if y was longer.
    }
