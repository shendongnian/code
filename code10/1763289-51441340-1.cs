    string str = @"\U+FF8D\U+FF9E\U+FF9D\U+FF84\U+FF9E\U+FF97\U+FF72\U+FF9D - \U+4E0BFooBar";
    var rx = new Regex(@"\\U\+([0-9A-F]{4})");
    string str2 = rx.Replace(str, m =>
    {
        ushort u = Convert.ToUInt16(m.Groups[1].Value, 16);
        return ((char)u).ToString();
    });
