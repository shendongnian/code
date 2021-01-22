    public void WriteBytesToFile(string filename, byte[] contents)
    {
        using(FileStream fs = 
            new FileStream("C:\\UpdloadDir\\"+filename, FileMode.Create))
        {
            fs.Write(contents, 0, contents.Length);
        }
    }
