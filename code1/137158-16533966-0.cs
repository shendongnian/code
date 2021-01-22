    /// <summary>
    /// Returns whether the bit at the specified position is set.
    /// </summary>
    /// <typeparam name="T">Any integer type.</typeparam>
    /// <param name="t">The value to check.</param>
    /// <param name="pos">
    /// The position of the bit to check, 0 refers to the least significant bit.
    /// </param>
    /// <returns>true if the specified bit is on, otherwise false.</returns>
    public static bool IsBitSet<T>(this T t, int pos) where T : struct, IConvertible
    {
     var value = t.ToInt64(CultureInfo.CurrentCulture);
     return (value & (1 << pos)) != 0;
    }
