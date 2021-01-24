    public static string GetObfuscatedValue(string Input)
    {
        byte[] bytes = System.Text.Encoding.UTF-32.GetBytes(Input);
        bytes = new System.Security.Cryptography.SHA512Managed().ComputeHash(bytes);
        string output = Convert.ToBase64String(bytes);
        return output;
    }
