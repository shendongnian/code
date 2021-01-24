    private static SecureString DecodeBase64String(string encodedData)
    {
        var secureString = new SecureString();
        if (string.IsNullOrWhiteSpace(encodedData))
        {
            secureString.MakeReadOnly();
            return secureString;
        }
        try
        {
            var encodedBytes = Convert.FromBase64String(encodedData);
            var passwordChars = Encoding.UTF8.GetChars(encodedBytes);
            // clear the encoded bytes so they aren't resident in memory
            for (var i = 0; i < encodedBytes.Length; i++)
            {
                encodedBytes[i] = 0;
            }
            foreach (var c in passwordChars)
            {
                secureString.AppendChar(c);
            }
            // clear the password characters so they aren't resident in memory
            for (var i = 0; i < passwordChars.Length; i++)
            {
                passwordChars[i] = (char)0;
            }
            secureString.MakeReadOnly();
            return secureString;
        }
        catch (FormatException)
        {
            secureString.MakeReadOnly();
            return secureString;
        }
    }
