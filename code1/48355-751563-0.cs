    private static MD5 md5 = MD5.Create();
    public static Guid ComputeHash(object value)
    {
        Guid g = Guid.Empty;
        BinaryFormatter bf = new BinaryFormatter();
        using (MemoryStream stm = new MemoryStream())
        {
            bf.Serialize(stm, value);
            g = new Guid(md5.ComputeHash(stm.ToArray()));
            stm.Close();
        }
        return g;
    }
