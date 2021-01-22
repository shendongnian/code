    private string GenerateUniqueId()
    {
        byte[] rndBytes = new byte[4];
        RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
        rng.GetBytes(rndBytes);
        return BitConverter.ToUInt32(rndBytes, 0).ToString();
    }
