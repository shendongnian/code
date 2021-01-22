    public static Bitmap LoadBitmap(string path)
    {
        //Open file in read only mode
        using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
        //Get a binary reader for the file stream
        using (BinaryReader reader = new BinaryReader(stream))
        {
            //copy the content of the file into a memory stream
            var memoryStream = new MemoryStream(reader.ReadBytes((int)stream.Length));
            //make a new Bitmap object the owner of the MemoryStream
            return new Bitmap(memoryStream);
        }
    }
