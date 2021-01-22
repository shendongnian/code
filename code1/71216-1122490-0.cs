    private readonly Random _rng = new Random();
    private string RandomString(int size)
    {
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < size; i++)
        {
            char ch = Convert.ToChar(Convert.ToInt32(
                Math.Floor(26 * _rng.NextDouble() + 65)));
            builder.Append(ch);
        }
        return builder.ToString();
    }
