    private Random _random = new Random(Environment.TickCount);
    public string RandomString(int length)
    {
        string chars = "0123456789abcdefghijklmnopqrstuvwxyz";
        StringBuilder builder = new StringBuilder(length);
        for (int i = 0; i < length; ++i)
            builder.Append(chars[_random.Next(chars.Length)]);
        return builder.ToString();
    }
