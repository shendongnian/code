    /// <summary>
    /// Extracts a nibble from a large number.
    /// </summary>
    /// <typeparam name="T">Any integer type.</typeparam>
    /// <param name="t">The value to extract nibble from.</param>
    /// <param name="nibblePos">The nibble to check,
    /// where 0 is the least significant nibble.</param>
    /// <returns>The extracted nibble.</returns>
    public static byte GetNibble<T>(this T t, int nibblePos)
     where T : struct , IConvertible
    {
     nibblePos *= 4;
     var value = t.ToInt64(CultureInfo.CurrentCulture);
     return (byte)((value >> nibblePos) & 0xF);
    }
