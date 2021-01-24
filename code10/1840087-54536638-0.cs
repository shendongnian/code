    SymmetricAlgorithm alg;
    IEnumerable<byte> key0 = key.Take(8);
    IEnumerable<byte> key1 = key.Skip(8).Take(8);
    IEnumerable<byte> key2 = key.Skip(16);
    if (key0.SequenceEquals(key1))
    {
        alg = DES.Create();
        alg.Key = key2.ToArray();
    }
    else if (key1.SequenceEquals(key2))
    {
        alg = DES.Create();
        alg.Key = key0.ToArray();
    }
    else
    {
        alg = TripleDES.Create();
        alg.Key = key;
    }
