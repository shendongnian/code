    var mt = new MersenneTwister(secretKey.ToUpperInvariant());
    var mr = new byte[256];
    for (int i = 0; i < 256; i++)
    {
        mr[i] = (byte)i;
    }
    var encryptionTable = mt.NextPermutation(mr);
    var decryptionTable = new byte[256];
    for (int i = 0; i < 256; i++)
    {
        decryptionTable[encryptionTable[i]] = (byte)i;
    }
    this._encryptionTable = encryptionTable;
    this._decryptionTable = decryptionTable;
