    public static List<string> urlEncodedCharacters = new List<string>
    {
      "/", "\\", "<", ">", ":", "\"", "|", "?", "%" //and others, but not *
    };
    //Since this is a superset of urlEncodedCharacters, we won't be able to only use UrlEncode() - instead we'll use HexEncode
    public static List<string> specialCharactersNotAllowedInWindows = new List<string>
    {
      "/", "\\", "<", ">", ":", "\"", "|", "?", "*" //windows dissallowed character set
    };
        public static string Encode(string fileName)
        {
            //CheckForFullPath(fileName); // optional: make sure it's not a path?
            List<string> charactersToChange = new List<string>(specialCharactersNotAllowedInWindows);
            charactersToChange.AddRange(urlEncodedCharacters.
                Where(x => !urlEncodedCharacters.Union(specialCharactersNotAllowedInWindows).Contains(x)));   // add any non duplicates (%)
            charactersToChange.ForEach(s => fileName = fileName.Replace(s, Uri.HexEscape(s[0])));   // "?" => "%3f"
            return fileName;
        }
