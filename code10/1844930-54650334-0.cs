    static void Main(string[] args)
    {
    
        var info = "ZipEntry: testfile.txt\n   Version Made By: 45\n Needed to extract: 45\n" +
            "         File type: binary\n       Compression: Deflate\n        " +
            "Compressed: 0x35556371\n      Uncompressed: 0x1D626FBDB\n  ";
        List<string> splittedinfo = info.Split('\n').ToList();
        Dictionary<string, string> d = new Dictionary<string, string>();
        foreach (string s in splittedinfo)
        {
            if (!string.IsNullOrEmpty(s.Trim()))
            {
                var ss = s.Split(':');
                d.Add(ss[0].Trim(), ss[1].Trim());
            }
        }
        Console.WriteLine( d["Compression"]);
        Console.ReadLine();
    }
