    public static decimal IncrementFractionalPortion(this decimal value)
    {
        return value.IncrementFractionalPortion(1);
    }
    
    public static decimal IncrementFractionalPortion(this decimal value, int amount)
    {
        int[] bits = decimal.GetBits(value + + 0.0m);
        bits[0] += amount;
        return new decimal(bits);
    }
