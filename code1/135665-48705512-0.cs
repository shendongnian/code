    static void WriteABC2(string filename)
    {
        string tempfile = Path.GetTempFileName();
        using (var writer = new FileStream(tempfile, FileMode.Create))
        using (var reader = new FileStream(filename, FileMode.Open))
        {
            var stringBytes = Encoding.UTF8.GetBytes("A,B,C" + Environment.NewLine);
            writer.Write(stringBytes, 0, stringBytes.Length);
            reader.CopyTo(writer);
        }
        File.Copy(tempfile, filename, true);
        File.Delete(tempfile);
    }
