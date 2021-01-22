    key = new RijndaelManaged();
    byte[] passwordBytes = Encoding.UTF8.GetBytes("Password1234"); //password here
    byte[] saltBytes = Encoding.UTF8.GetBytes("Salt"); // salt here (another string)
    Rfc2898DeriveBytes p = new Rfc2898DeriveBytes(passwordBytes, saltBytes);
    // sizes are devided by 8 because [ 1 byte = 8 bits ]
    key.IV = p.GetBytes(key.BlockSize / 8);
    key.Key = p.GetBytes(key.KeySize / 8);
