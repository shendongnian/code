    public static bool IsBinaryEqualTo(this object obj, object obj1)
    {
        using (MemoryStream memStream = new MemoryStream())
        {
            if (obj == null || obj1 == null)
            {
                if (obj == null && obj1 == null)
                    return true;
                else
                    return false;
            }
    
            BinaryFormatter binaryFormatter = new BinaryFormatter(null, new StreamingContext(StreamingContextStates.Clone));
            binaryFormatter.Serialize(memStream, obj);
            byte[] b1 = memStream.ToArray();
            memStream.SetLength(0);
    
            binaryFormatter.Serialize(memStream, obj1);
            byte[] b2 = memStream.ToArray();
    
            if (b1.Length != b2.Length)
                return false;
    
            for (int i = 0; i < b1.Length; i++)
            {
                if (b1[i] != b2[i])
                    return false;
            }
    
            return true;
        }
    }
