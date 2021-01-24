    private static RSA FromSubjectPublicKeyInfo(string pem)
    {
        AsnReader reader = new AsnReader(PemToBer(pem, SubjectPublicKeyInfo), AsnEncodingRules.DER);
        AsnReader spki = reader.ReadSequence();
        reader.ThrowIfNotEmpty();
        AsnReader algorithmId = spki.ReadSequence();
        if (algorithmId.ReadObjectIdentifierAsString() != "1.2.840.113549.1.1.1")
        {
            throw new InvalidOperationException();
        }
        algorithmId.ReadNull();
        algorithmId.ThrowIfNotEmpty();
        AsnReader rsaPublicKey = spki.ReadSequence();
        RSAParameters rsaParameters = new RSAParameters
        {
            Modulus = ReadNormalizedInteger(rsaPublicKey),
            Exponent = ReadNormalizedInteger(rsaPublicKey),
        };
        rsaPublicKey.ThrowIfNotEmpty();
        RSA rsa = RSA.Create();
        rsa.ImportParameters(rsaParameters);
        return rsa;
    }
    private static byte[] ReadNormalizedInteger(AsnReader reader)
    {
        ReadOnlyMemory<byte> memory = reader.ReadIntegerBytes();
        ReadOnlySpan<byte> span = memory.Span;
        if (span[0] == 0)
        {
            span = span.Slice(1);
        }
        return span.ToArray();
    }
