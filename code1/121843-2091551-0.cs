    static readonly Regex removeChars = new Regex("[-. ]", RegexOptions.Compiled);
    static void Main() {
        string path = "ab c.-def.ghi";
        string ext = Path.GetExtension(path);
        path = Path.ChangeExtension(
            removeChars.Replace(Path.ChangeExtension(path, null), "_"), ext);
    }
