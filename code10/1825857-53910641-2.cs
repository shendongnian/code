    public static bool ValidatePassword(string pass, string passCriptat, string salt)
        {
            string CryptedInput = CryptSharp.Crypter.Phpass.Crypt(Encoding.ASCII.GetBytes(pass), salt);
            string CryptedPassword = CryptSharp.Crypter.Phpass.Crypt(Encoding.ASCII.GetBytes(passCriptat), salt);
            return string.Equals(CryptedInput, CryptedPassword);
        }
