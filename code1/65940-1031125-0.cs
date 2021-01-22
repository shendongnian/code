    public object Clone()
    {
        object clonedObject = null;
        BinaryFormatter formatter = new BinaryFormatter();
        using (Stream stream = new MemoryStream())
        {
            formatter.Serialize(stream, this);
            stream.Seek(0, SeekOrigin.Begin);
    	    clonedObject = formatter.Deserialize(stream);
        }
    
        return clonedObject;
    }
