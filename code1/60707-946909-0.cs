    public static string ConvertToHex(byte[] value)
    {
        var sb = new System.Text.StringBuilder();
        for (int i = 0; i < sb.Length; i++)
            sb.Append(value[i].ToString("X"));
        return sb.ToString();
    }
