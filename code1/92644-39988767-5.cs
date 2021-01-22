    public static byte[] FileToByteArray(string fileName)
    {
        byte[] fileData = null;
   
        using (FileStream fs = File.OpenRead(fileName)) 
        { 
            var binaryReader = new BinaryReader(fs); 
            fileData = binaryReader.ReadBytes((int)fs.Length); 
        }
        return fileData;
    }
