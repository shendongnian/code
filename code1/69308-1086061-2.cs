    key = new RijndaelManaged();
    string password = "Password1234"; //password here
    byte[] saltBytes = Encoding.UTF8.GetBytes("Salt"); // salt here (another string)
    var p = new Rfc2898DeriveBytes(password, saltBytes); //TODO: think about number of iterations (third parameter)
    // sizes are devided by 8 because [ 1 byte = 8 bits ]
    key.IV = p.GetBytes(key.BlockSize / 8);
    key.Key = p.GetBytes(key.KeySize / 8);
