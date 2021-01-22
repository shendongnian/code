    public override bool Equals(object obj)
    {
        // If comparison object is null or is a different type, no further comparisons are necessary...
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }
        // Compare objects using byte arrays...
        using (MemoryStream memStream = new MemoryStream())
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter(null, new StreamingContext(StreamingContextStates.Clone));
            // Get byte array of "this" object...
            binaryFormatter.Serialize(memStream, this);
            byte[] b1 = memStream.ToArray();
            // Get byte array of object to be compared...
            memStream.SetLength(0);
            binaryFormatter.Serialize(memStream, obj);
            byte[] b2 = memStream.ToArray();
            // Compare array sizes. If equal, no further comparisons are necessary...
            if (b1.Length != b2.Length)
                return false;
            // If sizes are equal, compare each byte while inequality is not found...
            for (int i = 0; i < b1.Length; i++)
            {
                if (b1[i] != b2[i])
                    return false;
            }
        }
        return true;
    }
