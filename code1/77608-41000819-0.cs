    public static string ToXmlString(this XDocument xdoc, SaveOptions options = SaveOptions.None)
    {
        var newLine =  (options & SaveOptions.DisableFormatting) == SaveOptions.DisableFormatting ? "" : Environment.NewLine;
        return xdoc.Declaration == null ? xdoc.ToString(options) : xdoc.Declaration + newLine + xdoc.ToString(options);
    }
