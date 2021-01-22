    public void WriteFile(string fileName)
    {
        using (FileStream fs = new FileStream(fileName, FileMode.Create))
        {
            Stream s;
            if (Path.GetExtension(fileName) == ".cmx")
            {
                s = new GZipStream(fs, CompressionMode.Compress);
            }
            else if (Path.GetExtension(fileName) == ".cmz")
            {
                s = new DeflateStream(fs, CompressionMode.Compress);
            }
            else
            {
                s = fs;
            }
            WriteXml(s);
            s.Close();
        }
    } 
