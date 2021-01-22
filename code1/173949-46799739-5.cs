    public static void ByteArrayToStruct<T>(byte[] data, out T output)
    {
        output = (T) Activator.CreateInstance(typeof(T), null);
        using (MemoryStream ms = new MemoryStream(data))
        {
            byte[] ba = null;
            FieldInfo[] infos = typeof(T).GetFields(BindingFlags.Public | BindingFlags.Instance);
            foreach (FieldInfo info in infos)
            {
                // for length
                ba = new byte[sizeof(int)];
                ms.Read(ba, 0, sizeof(int));
         
                // for value
                int sz = BitConverter.ToInt32(ba, 0);
                ba = new byte[sz];
                ms.Read(ba, 0, sz);
         
                BinaryFormatter bf = new BinaryFormatter();
                using (MemoryStream inms = new MemoryStream(ba))
                {
                    info.SetValue(output, bf.Deserialize(inms));
                }
            }
        }
    }
