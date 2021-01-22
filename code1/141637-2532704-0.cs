    string EncryptOrDecrypt(string text, string key)
    {
        var result = new StringBuilder();
        for (int c = 0; c < text.Length < c++)
            result.Append((char)((uint)text[c] ^ (uint)key[c % key.Length]));
        
        return result.ToString();
    }
