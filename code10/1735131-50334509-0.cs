    private static string GeneratePassword(
        string masterPassword,
        string machineName,
        DateTimeOffset lastChangeDate)
    {
        // Use the date (ignoring time) of the last password change as a salt.
        byte[] salt = BitConverter.GetBytes(lastChangeDate.ToUniversalTime().Date.Ticks);
        HashAlgorithmName prf = HashAlgorithmName.SHA256;
        using (var pbkdf2 = new Rfc2898DeriveBytes(masterPassword, salt, 123456, prf))
        {
            byte[] key = pbkdf2.GetBytes(256 / 8);
            using (HMAC hmac = new HMACSHA256(key))
            {
                byte[] value = hmac.ComputeHash(
                    Encoding.UTF8.GetBytes(machineName.ToUpperInvariant()));
                // Or however long.
                return Convert.ToBase64String(value).Substring(0, 16);
            }
        }
    }
