    /// <summary>
    /// Isolates the text in between the parameters, exclusively, using invariant, case-sensitive comparison. 
    /// Both parameters may be null to skip either step. If specified but not found, a FormatException is thrown.
    /// </summary>
    public static string Isolate(this string str, string entryString, string exitString)
        {
            if (!string.IsNullOrEmpty(entryString))
            {
                int entry = str.IndexOf(entryString, StringComparison.InvariantCulture);
                if (entry == -1) throw new FormatException($"String.Isolate failed: \"{entryString}\" not found in string \"{str.Truncate(80)}\".");
                str = str.Substring(entry + entryString.Length);
            }
            if (!string.IsNullOrEmpty(exitString))
            {
                int exit = str.IndexOf(exitString, StringComparison.InvariantCulture);
                if (exit == -1) throw new FormatException($"String.Isolate failed: \"{exitString}\" not found in string \"{str.Truncate(80)}\".");
                str = str.Substring(0, exit);
            }
            return str;
        }
