    byte[] bytes = new byte[0];
    //pass in your API response into the bytes initialized
   
    using (StreamWriter streamWriter = new StreamWriter(FilePath, true))
    
    {
       BinaryWriter binaryWriter = new BinaryWriter(streamWriter.BaseStream);
       binaryWriter.Write(bytes);
    }
