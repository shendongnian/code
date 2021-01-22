    string encode = secretkey + email;
    SHA1 sha1 = SHA1CryptoServiceProvider.Create();
    byte[] encodeBytes = Encoding.ASCII.GetBytes(encode);
    byte[] encodeHashedBytes = sha1.ComputeHash(passwordBytes);
    string pencodeHashed = BitConverter.
    ToString(encode HashedBytes).Replace("-", "").ToLowerInvariant();
