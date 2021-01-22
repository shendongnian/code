    public static string Reverse(string sz) // ideal for an extension method
    {
        if (string.IsNullOrEmpty(sz) || sz.Length == 1) return sz;
        char[] chars = sz.ToCharArray();
        Array.Reverse(chars);
        return new string(chars);
    }
