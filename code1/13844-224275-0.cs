    static void WriteShorts(short[] values, string path)
    {
        using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
        {
            using (BinaryWriter bw = new BinaryWriter(fs))
            {
                // Write the number of items
                bw.Write(values.Length);
                
                foreach (short value in values)
                {
                    bw.Write(value);
                }
            }
        }
    }
