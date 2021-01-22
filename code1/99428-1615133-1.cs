    private static readonly object monitor = new object();
    public static TYPE Property
    {
        get
        {
            lock(monitor)
            {
                // check if data has not changed
                // if it has not, just read
                using (Stream stream = File.Open(fileLocation, 
                       FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    ....
                }
                // else, if data changed, then need to write to 
                // file to save the new data
                using (Stream stream = File.Open
                           (fileLocation, FileMode.OpenOrCreate,
                            FileAccess.ReadWrite, FileShare.Read))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(stream, data);
                }
                return data;
            }
        }
    }
