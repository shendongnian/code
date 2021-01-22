    byte[] pwdAndSalt = new byte[pwd.Length + salt.Length];
    for (int i = 0; i < pwdAndSalt.Length; i++)
    {
        if (i < salt.Length)
        {
            pwdAndSalt[i] = salt[i];
        }
        else
        {
            pwdAndSalt[i] = pwd[i - salt.Length];
        }
    }
