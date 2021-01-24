    static void Main(string[] args)
    {
    
        var info = "ZipEntry: testfile.txt\n   Version Made By: 45\n Needed to extract: 45\n" +
            "         File type: binary\n       Compression: Deflate\n        " +
            "Compressed: 0x35556371\n      Uncompressed: 0x1D626FBDB\n  ";
        List<string> splittedinfo = info.Split('\n');
        foreach (string s in splittedinfo)
        {
            if (!string.IsNullOrEmpty(s.Trim()))
            {
                var ss = s.Split(':');
                if (ss[0].Trim() == "Compression")
                {
                    Console.WriteLine(ss[1]);
                    break;
                }
            }
        }
        Console.ReadLine();
    }
