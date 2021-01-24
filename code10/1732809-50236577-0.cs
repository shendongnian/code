    private static readonly byte[] s_derIntegerZero = { 0x02, 0x01, 0x00 };
    private static readonly byte[] s_rsaAlgorithmId =
    {
        0x30, 0x0D,
        0x06, 0x09, 0x2A, 0x86, 0x48, 0x86, 0xF7, 0x0D, 0x01, 0x01, 0x01,
        0x05, 0x00,
    };
    private static int ReadLength(byte[] data, ref int offset)
    {
        byte lengthOrLengthLength = data[offset++];
        if (lengthOrLengthLength < 0x80)
        {
            return lengthOrLengthLength;
        }
        int lengthLength = lengthOrLengthLength & 0x7F;
        int length = 0;
        for (int i = 0; i < lengthLength; i++)
        {
            if (length > ushort.MaxValue)
            {
                throw new InvalidOperationException("This seems way too big.");
            }
            length <<= 8;
            length |= data[offset++];
        }
        return length;
    }
    private static byte[] ReadUnsignedInteger(byte[] data, ref int offset, int targetSize = 0)
    {
        if (data[offset++] != 0x02)
        {
            throw new InvalidOperationException("Invalid encoding");
        }
        int length = ReadLength(data, ref offset);
        // Encoding rules say 0 is encoded as the one byte value 0x00.
        // Since we expect unsigned, throw if the high bit is set.
        if (length < 1 || data[offset] >= 0x80)
        {
            throw new InvalidOperationException("Invalid encoding");
        }
        byte[] ret;
        if (length == 1)
        {
            ret = new byte[length];
            ret[0] = data[offset++];
            return ret;
        }
        if (data[offset] == 0)
        {
            offset++;
            length--;
        }
        if (targetSize != 0)
        {
            if (length > targetSize)
            {
                throw new InvalidOperationException("Bad key parameters");
            }
            ret = new byte[targetSize];
        }
        else
        {
            ret = new byte[length];
        }
        Buffer.BlockCopy(data, offset, ret, ret.Length - length, length);
        offset += length;
        return ret;
    }
    private static void EatFullPayloadTag(byte[] data, ref int offset, byte tagValue)
    {
        if (data[offset++] != tagValue)
        {
            throw new InvalidOperationException("Invalid encoding");
        }
        int length = ReadLength(data, ref offset);
        if (data.Length - offset != length)
        {
            throw new InvalidOperationException("Data does not represent precisely one value");
        }
    }
    private static void EatMatch(byte[] data, ref int offset, byte[] toMatch)
    {
        if (data.Length - offset > toMatch.Length)
        {
            if (data.Skip(offset).Take(toMatch.Length).SequenceEqual(toMatch))
            {
                offset += toMatch.Length;
                return;
            }
        }
        throw new InvalidOperationException("Bad data.");
    }
    private static RSA DecodeRSAPkcs8(byte[] pkcs8Bytes)
    {
        int offset = 0;
        // PrivateKeyInfo SEQUENCE
        EatFullPayloadTag(pkcs8Bytes, ref offset, 0x30);
        // PKCS#8 PrivateKeyInfo.version == 0
        EatMatch(pkcs8Bytes, ref offset, s_derIntegerZero);
        // rsaEncryption AlgorithmIdentifier value
        EatMatch(pkcs8Bytes, ref offset, s_rsaAlgorithmId);
        // PrivateKeyInfo.privateKey OCTET STRING
        EatFullPayloadTag(pkcs8Bytes, ref offset, 0x04);
        // RSAPrivateKey SEQUENCE
        EatFullPayloadTag(pkcs8Bytes, ref offset, 0x30);
        // RSAPrivateKey.version == 0
        EatMatch(pkcs8Bytes, ref offset, s_derIntegerZero);
        RSAParameters rsaParameters = new RSAParameters();
        rsaParameters.Modulus = ReadUnsignedInteger(pkcs8Bytes, ref offset);
        rsaParameters.Exponent = ReadUnsignedInteger(pkcs8Bytes, ref offset);
        rsaParameters.D = ReadUnsignedInteger(pkcs8Bytes, ref offset, rsaParameters.Modulus.Length);
        int halfModulus = (rsaParameters.Modulus.Length + 1) / 2;
        rsaParameters.P = ReadUnsignedInteger(pkcs8Bytes, ref offset, halfModulus);
        rsaParameters.Q = ReadUnsignedInteger(pkcs8Bytes, ref offset, halfModulus);
        rsaParameters.DP = ReadUnsignedInteger(pkcs8Bytes, ref offset, halfModulus);
        rsaParameters.DQ = ReadUnsignedInteger(pkcs8Bytes, ref offset, halfModulus);
        rsaParameters.InverseQ = ReadUnsignedInteger(pkcs8Bytes, ref offset, halfModulus);
        if (offset != pkcs8Bytes.Length)
        {
            throw new InvalidOperationException("Something didn't add up");
        }
        RSA rsa = RSA.Create();
        rsa.ImportParameters(rsaParameters);
        return rsa;
    }
