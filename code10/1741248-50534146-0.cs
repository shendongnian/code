    var skipCodepages = new[] { Encoding.ASCII.CodePage, Encoding.UTF7.CodePage, Encoding.UTF8.CodePage, Encoding.Unicode.CodePage, Encoding.BigEndianUnicode.CodePage, Encoding.UTF32.CodePage, Encoding.GetEncoding("UTF-32BE").CodePage, Encoding.GetEncoding("GB18030").CodePage };
    var encodings = Encoding.GetEncodings().Where(x => Array.IndexOf(skipCodepages, x.CodePage) == -1).ToArray();
    foreach (var enc in encodings)
    {
        Console.WriteLine(enc.DisplayName);
    }
