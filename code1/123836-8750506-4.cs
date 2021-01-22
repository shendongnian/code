    public static byte[] Hash(string value, byte[] salt)
    {
        return Hash(Encoding.UTF8.GetBytes(value), salt);
    }
    public static byte[] Hash(byte[] value, byte[] salt)
    {
        byte[] saltedValue = value.Concat(salt).ToArray();
        // Alternatively use CopyTo.
        //var saltedValue = new byte[value.Length + salt.Length];
        //value.CopyTo(saltedValue, 0);
        //salt.CopyTo(saltedValue, value.Length);
        return new SHA256Managed().ComputeHash(saltedValue);
    }
