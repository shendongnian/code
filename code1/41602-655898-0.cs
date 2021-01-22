    public string GetBits(string input)
    {
        StringBuilder sb = new StringBuilder();
        foreach (byte b in Encoding.Unicode.GetBytes(input))
        {
            sb.Append(Convert.ToString(b, 2));
        }
        return sb.ToString();
    }
