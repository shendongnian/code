    public byte[] PublicDecryption(byte[] encryptedData)
    {
            var encData = new BigInteger(encryptedData);
            BigInteger bnData = encData.modPow(_exponent, _modulus);
            return bnData.getBytes();
    }
    public byte[] PrivateDecryption(byte[] encryptedData)
    {
        var encData = new BigInteger(encryptedData);
        d = new BigInteger(rsaParams.D);
        BigInteger bnData = encData.modPow(d, _modulus);
        return bnData.getBytes();
    }
