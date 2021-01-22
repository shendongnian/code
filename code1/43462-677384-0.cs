    // Assume rng refers to an instance of System.Random
    byte[] bytes = new byte[8];
    rng.NextBytes(bytes);
    long int64 = BitConverter.ToInt64(bytes, 0);
    ulong uint64 = BitConverter.ToUInt64(bytes, 0);
