    public static void TestIt(IFeatureClass fc)
    {
        string base64Name = GetFullName((IDataset)fc);
        Debug.Print(base64Name);
        IFeatureClass fc2 = OpenDataset(base64Name) as IFeatureClass;
        Debug.Print(fc2.AliasName);            
    }
    
    public static string GetFullName(IDataset ds)
    {
        IPersistStream ps = ds.FullName as IPersistStream;
        IMemoryBlobStream mbs = new MemoryBlobStreamClass();
        ps.Save(mbs,0);
        object bytes;
        ((IMemoryBlobStreamVariant)mbs).ExportToVariant(out bytes);
        return Convert.ToBase64String((byte[])bytes);
    }
    
    public static IDataset OpenDataset(string base64Name)
    {
        byte[] bytes = Convert.FromBase64String(base64Name);
        IMemoryBlobStream mbs = new MemoryBlobStreamClass();
        ((IMemoryBlobStreamVariant)mbs).ImportFromVariant(bytes);
        IName n = new FeatureClassNameClass();
        ((IPersistStream)n).Load(mbs);
        IDataset ds = n.Open() as IDataset;
        return ds;
    }
