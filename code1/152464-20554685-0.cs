    static string EncodeHeaderValue(string value)
    {
        return Regex.Replace(value, @"[\u0000-\u0008\u000a-\u001f%\u007f]", (m) => "%"+((int)m.Value[0]).ToString("x2"));
    }
    static string DecodeHeaderValue(string encoded)
    {
        return Regex.Replace(encoded, @"%([0-9a-f]{2})", (m) => new String((char)Convert.ToInt32(m.Groups[1].Value, 16), 1), RegexOptions.IgnoreCase);
    }
