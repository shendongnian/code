    public void WriteBinaryFile(string path, byte[] data)
    {
        using (System.IO.FileStream stream = new System.IO.FileStream(path, System.IO.FileMode.Create))
        {
            stream.Write(data, 0, data.Length);
        }
    }
