    /// <summary>
    /// Divides a/b, rounding negative numbers towards -Inf.
    /// </summary>
    /// <param name="a">Dividend</param>
    /// <param name="b">Divisor; must be positive for correct results</param>
    /// <returns>a ÷ b</returns>
    public static int Div(int a, int b)
    {
        return a < 0 ? (a - b + 1) / b : a / b;
    }
