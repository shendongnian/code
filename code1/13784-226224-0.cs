    using (MemoryStream memstream = new MemoryStream())
    {
        BinaryFormatter formatter = new BinaryFormatter();
    
        try
        {
            formatter.Serialize(memstream, myObjectOfObjects);
            mem_footprint += memstream.Length;
        }
        catch 
        {
            // not a serializable object 
        }
    }
