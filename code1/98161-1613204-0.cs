    internal static T CloneEntity<T>(T originalEntity)
    {
        Type entityType = typeof(T);
    
        DataContractSerializer ser =
            new DataContractSerializer(entityType);
    
        using (MemoryStream ms = new MemoryStream())
        {
            ser.WriteObject(ms, originalEntity);
            ms.Position = 0;
            return (T)ser.ReadObject(ms);
        }
    }
