    public string RandomString(int length)
    {
        Random r = new Random(Environment.TickCount);
        string chars = "0123456789abcdefghijklmnopqrstuvwxyz";
        StringBuilder builder = new StringBuilder(length);
        for (int i = 0; i < length; ++i)
        {
            builder.Append(chars[r.Next(chars.Length)]);
        }
        return builder.ToString();
    }
