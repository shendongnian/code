    public static decimal IncrementLowestDigit(this decimal value, int amount)
    {
        int[] bits = decimal.GetBits(value);
        if (bits[0] == -1 || (bits[0] == -2 && amount > 1))
        {
            bits[1]++;
            if (bits[1] == 0)
            {
                bits[2]++;
            }
        }
        bits[0] += amount;
        return new decimal(bits);
    }
