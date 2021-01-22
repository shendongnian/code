    static void Main(string[] args)
    {
        //Simulate a large file
        int size = 100 * 1024 * 1024;
        string filename = "blah.datn";
        using (var fs = new FileStream(filename, FileMode.Create))
        {
            fs.SetLength(size);
        }
        using (var fs = new FileStream(filename, FileMode.Open))
        {
            fs.Seek(-1, SeekOrigin.End);
            fs.WriteByte(255);
        }
    }
