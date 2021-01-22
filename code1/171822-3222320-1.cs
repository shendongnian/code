    static void Main(string[] args)
    {
        string filename = "blah.datn";
        using (var fs = new FileStream(filename, FileMode.Open))
        {
            fs.Seek(-1, SeekOrigin.End);
            fs.WriteByte(255);
        }
    }
