    public static void TestIt(IFeatureClass fc)
    {
        string guidplusbase64Name = GetFullName((IDataset)fc);
        Debug.Print(guidplusbase64Name);
        IFeatureClass fc2 = OpenDataset(guidplusbase64Name) as IFeatureClass;
        Debug.Print(fc2.AliasName);            
    }
    
    public static string GetFullName(IDataset ds)
    {
        IPersistStream ps = ds.FullName as IPersistStream;
        Guid g;
        ps.GetClassID(out g);            
        IMemoryBlobStream mbs = new MemoryBlobStreamClass();
        ps.Save(mbs,0);
        object bytes;
        ((IMemoryBlobStreamVariant)mbs).ExportToVariant(out bytes);            
        return String.Format("{0};{1}",g,Convert.ToBase64String((byte[])bytes));
    }
    
    public static IDataset OpenDataset(string guidplusbase64Name)
    {
        int idx = guidplusbase64Name.IndexOf(";");
        string base64Name = guidplusbase64Name.Substring(idx+1);
        string guidString = guidplusbase64Name.Substring(0, idx);
    
        byte[] bytes = Convert.FromBase64String(base64Name);
        IMemoryBlobStream mbs = new MemoryBlobStreamClass();
        ((IMemoryBlobStreamVariant)mbs).ImportFromVariant(bytes);
        Type t = Type.GetTypeFromCLSID(new Guid(guidString));
        IName n = Activator.CreateInstance(t) as IName;
        ((IPersistStream)n).Load(mbs);
        IDataset ds = n.Open() as IDataset;
        return ds;
    }
