        System.Security.Cryptography.SHA512 sha512 = new System.Security.Cryptography.SHA512Managed();
        var saltedUtf8Bytes = System.Text.Encoding.UTF8.GetBytes(salted);
        for(int i = 1; i < 5000; i++) 
        {
            digest = sha512.ComputeHash(digest.Concat(saltedUtf8Bytes).ToArray());
        }
