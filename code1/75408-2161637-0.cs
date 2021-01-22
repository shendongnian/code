    string[] orig = {
        "folder1/folder2/page1.aspx",
        "folderBB/folderAA/page2.aspx",
    };
    public void Run()
    {
        foreach (string s in orig)
        {
            System.Console.WriteLine("original    : {0}", s);
            byte[] compressed = DeflateStream.CompressString(s);
            System.Console.WriteLine("compressed  : {0}", ByteArrayToHexString(compressed));
            string uncompressed = DeflateStream.UncompressString(compressed);
            System.Console.WriteLine("uncompressed: {0}\n", uncompressed);
        }
    }
