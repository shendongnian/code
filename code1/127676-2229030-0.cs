    private string UnEncodePassword(string encodedPassword)
    {
        string password = encodedPassword;
        byte[] bytesIn = Convert.FromBase64String(encodedPassword);
        byte[] bytesRet = DecryptPassword(bytesIn);
        password = System.Text.Encoding.Unicode.GetString(bytesRet, 16, bytesRet.Length - 16);
        
        return password;
    }
