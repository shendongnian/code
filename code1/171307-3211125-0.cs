    static IEnumerable<T[]> LinqChunks<T>(IEnumerable<T> input, int chunkSize)
    {
      return input
        //assign chunk numbers to elements by integer division
        .Select((x, index) => new {ChunkNr = index / chunkSize, Value = x})
        //group by chunk number
        .GroupBy(item => item.ChunkNr)
        //convert chunks to arrays, and pad with zeroes if necessary
        .Select(group =>
                  {
                    var block = group.Select(item => item.Value).ToArray();
                    
                    //if block size = chunk size -> return the block
                    if (block.Length == chunkSize) return block;
                    //if block size < chunk size -> this is the last block, pad it
                    var lastBlock= new T[chunkSize];
                    for (int i = 0; i < block.Length; i++) lastBlock[i] = block[i];
                    return lastBlock;
                  });
    }
