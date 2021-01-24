    private static RSA FromRSAPrivateKey(string pem)
    {
        AsnReader reader = new AsnReader(PemToBer(pem, RsaPrivateKey), AsnEncodingRules.DER);
        AsnReader rsaPrivateKey = reader.ReadSequence();
        reader.ThrowIfNotEmpty();
        if (!rsaPrivateKey.TryReadInt32(out int version) || version != 0)
        {
            throw new InvalidOperationException();
        }
        byte[] modulus = ReadNormalizedInteger(rsaPrivateKey);
        int halfModulusLen = (modulus.Length + 1) / 2;
        RSAParameters rsaParameters = new RSAParameters
        {
            Modulus = modulus,
            Exponent = ReadNormalizedInteger(rsaPrivateKey),
            D = ReadNormalizedInteger(rsaPrivateKey, modulus.Length),
            P = ReadNormalizedInteger(rsaPrivateKey, halfModulusLen),
            Q = ReadNormalizedInteger(rsaPrivateKey, halfModulusLen),
            DP = ReadNormalizedInteger(rsaPrivateKey, halfModulusLen),
            DQ = ReadNormalizedInteger(rsaPrivateKey, halfModulusLen),
            InverseQ = ReadNormalizedInteger(rsaPrivateKey, halfModulusLen),
        };
        rsaPrivateKey.ThrowIfNotEmpty();
        RSA rsa = RSA.Create();
        rsa.ImportParameters(rsaParameters);
        return rsa;
    }
    private static byte[] ReadNormalizedInteger(AsnReader reader, int length)
    {
        ReadOnlyMemory<byte> memory = reader.ReadIntegerBytes();
        ReadOnlySpan<byte> span = memory.Span;
        if (span[0] == 0)
        {
            span = span.Slice(1);
        }
        byte[] buf = new byte[length];
        int skipSize = length - span.Length;
        span.CopyTo(buf.AsSpan(skipSize));
        return buf;
    }
