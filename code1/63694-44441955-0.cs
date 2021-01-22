    private static BigInteger GetBigInteger(byte[] bytes)
    {
        byte[] signPadded = new byte[bytes.Length + 1];
        Buffer.BlockCopy(bytes, 0, signPadded, 1, bytes.Length);
        Array.Reverse(signPadded);
        return new BigInteger(signPadded);
    }
