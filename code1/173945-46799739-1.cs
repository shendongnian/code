    public static byte[] StructToByteArray<T>(T obj)
    {
        using (MemoryStream ms = new MemoryStream())
        {
            FieldInfo[] infos = typeof(T).GetFields(BindingFlags.Public | BindingFlags.Instance);
            foreach (FieldInfo info in infos)
            {
                BinaryFormatter bf = new BinaryFormatter();
                using (MemoryStream inms = new MemoryStream()) {
                    
                    bf.Serialize(inms, info.GetValue(obj));
                    byte[] ba = inms.ToArray();
                    ms.Write(BitConverter.GetBytes(ba.Length), 0, sizeof(int));
                    ms.Write(ba, 0, ba.Length);
                }
            }
            return ms.ToArray();
        }
    }
