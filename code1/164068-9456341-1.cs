    /// <summary>
    /// Divides a/b, rounding negative numbers towards -Inf.
    /// </summary>
    /// <param name="a">Dividend</param>
    /// <param name="b">Divisor</param>
    /// <returns>a/b</returns>
    public static int Div(int a, int b)
    {
        return a < 0 != b < 0 ? (a / b) - 1 : a / b;
    }
