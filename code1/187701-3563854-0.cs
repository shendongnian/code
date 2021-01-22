    public static byte[] DecimalToByteArray (decimal src) 
    {
        using (MemoryStream stream = new MemoryStream()) 
        {
            using (BinaryWriter writer = new BinaryWriter(stream))
            {
                writer.Write(src);
                return stream.ToArray();
            }
        }
    }
    
    Decimal myDecimal = 1234.5678M;
    Guid guid = new Guid(DecimalToByteArray(myDecimal));
