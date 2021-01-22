    private byte[] EncryptBytes(byte[] key, byte[] plaintext)
    {
        using (var cipher = new RijndaelManaged { Key = key })
        {
            using (var encryptor = cipher.CreateEncryptor())
            {
                var ciphertext = encryptor.TransformFinalBlock(plaintext, 0, plaintext.Length);
    
                // IV is prepended to ciphertext
                return cipher.IV.Concat(ciphertext).ToArray();
            }
        }
    }
    
    private byte[] DecryptBytes(byte[] key, byte[] packed)
    {
        using (var cipher = new RijndaelManaged { Key = key })
        {
            int ivSize = cipher.BlockSize / 8;
    
            cipher.IV = packed.Take(ivSize).ToArray();
    
            using (var encryptor = cipher.CreateDecryptor())
            {
                return encryptor.TransformFinalBlock(packed, ivSize, packed.Length - ivSize);
            }
        }
    }
    
    private byte[] AddMac(byte[] key, byte[] data)
    {
        using (var hmac = new HMACSHA256(key))
        {
            var macBytes = hmac.ComputeHash(data);
    
            // HMAC is appended to data
            return data.Concat(macBytes).ToArray();
        }
    }
    
    private bool BadMac(byte[] found, byte[] computed)
    {
        int mismatch = 0;
    
        // Aim for consistent timing regardless of inputs
        for (int i = 0; i < found.Length; i++)
        {
            mismatch += found[i] == computed[i] ? 0 : 1;
        }
    
        return mismatch != 0;
    }
    
    private byte[] RemoveMac(byte[] key, byte[] data)
    {
        using (var hmac = new HMACSHA256(key))
        {
            int macSize = hmac.HashSize / 8;
    
            var packed = data.Take(data.Length - macSize).ToArray();
    
            var foundMac = data.Skip(packed.Length).ToArray();
    
            var computedMac = hmac.ComputeHash(packed);
    
            if (this.BadMac(foundMac, computedMac))
            {
                throw new Exception("Bad MAC");
            }
    
            return packed;
        }            
    }
    
    private List<byte[]> DeriveTwoKeys(string password)
    {
        var salt = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
    
        var kdf = new Rfc2898DeriveBytes(password, salt, 10000);
    
        var bytes = kdf.GetBytes(32); // Two keys 128 bits each
    
        return new List<byte[]> { bytes.Take(16).ToArray(), bytes.Skip(16).ToArray() };
    }
    
    public byte[] EncryptString(string password, String message)
    {
        var keys = this.DeriveTwoKeys(password);
    
        var plaintext = Encoding.UTF8.GetBytes(message);
    
        var packed = this.EncryptBytes(keys[0], plaintext);
    
        return this.AddMac(keys[1], packed);
    }
    
    public String DecryptString(string password, byte[] secret)
    {
        var keys = this.DeriveTwoKeys(password);
    
        var packed = this.RemoveMac(keys[1], secret);
    
        var plaintext = this.DecryptBytes(keys[0], packed);
    
        return Encoding.UTF8.GetString(plaintext);
    }
    
    public void Example()
    {
        var password = "correcthorsebatterystaple";
    
        var secret = this.EncryptString(password, "Hello World");
    
        Console.WriteLine("secret: " + BitConverter.ToString(secret));
    
        var recovered = this.DecryptString(password, secret);
    
        Console.WriteLine(recovered);
    }
