    public void EatMemory()
    {
        List<byte[]> wastedMemory = new List<byte[]>();
        
        while(true)
        {
            byte[] buffer = new byte[4096]; // Allocate 4kb
            wastedMemory.Add(buffer);
        }
    }
