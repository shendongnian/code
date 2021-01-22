    private string GenerateUniqueId()
    {
        using (var rng = new RNGCryptoServiceProvider())
        {
            // change the size of the array depending on your requirements
            var rndBytes = new byte[8];
            rng.GetBytes(rndBytes);
            return BitConverter.ToString(rndBytes).Replace("-", "");
        }
    }
