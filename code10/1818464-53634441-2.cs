    public static bool TryDecrypt(string inputText, out string result)
    {
        try
        {
            result = Decrypt(inputText);
            return true;
        }
        catch
        {
            result = null;
            return false;
        }
    }
