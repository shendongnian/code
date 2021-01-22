    public
    static byte[] Serialize(Object o)
    {
       using (MemoryStream ms = new MemoryStream())
       using (BinaryFormatter bf1 = new BinaryFormatter())
       {
           bf1.Serialize(ms, o);
           byte[] buffer = ms.ToArray();
           //string retStr = Convert.ToBase64String(buffer);
       }
       return buffer;
    }
    public static object Deserialize(byte[] TheByteArray)
    {
       //byte[] TheByteArray = Convert.FromBase64String(ParamStr);
       using (MemoryStream ms = new MemoryStream(TheByteArray))
       using (BinaryFormatter bf1 = new BinaryFormatter())
       {
           ms.Position = 0;
           var result = bf1.Deserialize(ms);
       }
       return result;
    }
