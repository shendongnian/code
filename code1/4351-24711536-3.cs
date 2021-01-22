    public string GenerateToken(int length)
    {
        using (RNGCryptoServiceProvider cryptRNG = new RNGCryptoServiceProvider())
        {
            byte[] tokenBuffer = new byte[length];
            cryptRNG.GetBytes(tokenBuffer);
            return Convert.ToBase64String(tokenBuffer);
        }
    }
