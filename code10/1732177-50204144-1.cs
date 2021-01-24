    string Encrypt(string value, SecureString password, string salt)
    {
        try
        {
            
            var temp = Marshal.SecureStringToGlobalAllocUnicode(password);
            var lengthInBytes = sizeof(char) * password.Length;
            // The rest of the encription code...
        }
        finally
        {
            //Cleanup
            Marshal.ZeroFreeGlobalAllocUnicode(temp);
        }
    }
    string Decrypt(string value, SecureString password, string salt)
    {
        try
        {
            
            var temp = Marshal.SecureStringToGlobalAllocUnicode(password);
            var lengthInBytes = sizeof(char) * password.Length;
            // The rest of the decryption code...
        }
        finally
        {
            //Cleanup
            Marshal.ZeroFreeGlobalAllocUnicode(temp);
        }
    }
