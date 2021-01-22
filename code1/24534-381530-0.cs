    protected bool SaveData(string FileName, byte[] Data)
    {
        BinaryWriter Writer = null;
        string Name = @"C:\temp\yourfile.name";;
        try
        {
            // Create a new stream to write to the file
            Writer = new BinaryWriter(File.OpenWrite(Name));
            // Writer raw data                
            Writer.Write(Data);
            Writer.Flush();
            Writer.Close();
        }
        catch 
        {
            //...
            return false;
        }
        
        return true;
    }
