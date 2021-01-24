    // expected format is SEQUENCE {INTEGER r, INTEGER s}
    var derSignature = new DerSequence(
        // first 32 bytes is "r" number
        new DerInteger(new BigInteger(1, signature.Take(32).ToArray())),
        // last 32 bytes is "s" number
        new DerInteger(new BigInteger(1, signature.Skip(32).ToArray())))
        .GetDerEncoded();
