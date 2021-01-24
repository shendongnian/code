    public async Task<string> DecryptAsync(string encrypted)
    {
        using (SymmetricAlgorithm aes = this.GetAes())
        {
            string decryptedText = await this.DecryptAsync(aes, encrypted);
            return decryptedText;
        };
    }
