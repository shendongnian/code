    //making chunks (size of 10)
        List<List<byte>> listOfChunks = new List<List<byte>>();
        List<byte> chunks = new List<byte>();
        for (int i = 0; i < mainInputList.Count; i++)
        {
            chunks.Add(array[i]);
            if (chunks.Count == 10)
            {
                listOfChunks.Add(chunks);
                chunks = new List<byte>();
            }
        }
        if (chunks.Count > 0)
            listOfChunks.Add(chunks);
