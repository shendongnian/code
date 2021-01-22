    public static string FormatAllowed(string allowedFormats)
    {
        var formats = allowedFormats.Split(new[] {'|'}, 
                                StringSplitOptions.RemoveEmptyEntries);
        return formats.Length == 0 ? "No formats allowed" :
               formats.Length == 1 ? "Allowed format is \"" + formats[0] + "\"" :
               string.Join("", 
                   formats.Select(
                       (format, index) => 
                           (index == 0 ? "Allowed formats are " :
                           (index == formats.Length - 1 ? " and " : ", ")) +
                           "\"" + format + "\"")
                          .ToArray());
    }
