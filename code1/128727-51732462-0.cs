    /// <summary>Gets the bit array value from the specified range in a bit vector.</summary>
    /// <typeparam name="T">The type of the bit vector. Must be of type <see cref="IConvertible"/>.</typeparam>
    /// <param name="bits">The bit vector.</param>
    /// <param name="startIdx">The zero-based start index of the bit range to get.</param>
    /// <param name="count">The number of sequential bits to fetch starting at <paramref name="startIdx"/>.</param>
    /// <returns>The value of the requested bit range.</returns>
    public static T GetBits<T>(T bits, byte startIdx, byte count) where T : IConvertible
    {
        if (startIdx >= (Marshal.SizeOf(typeof(T)) * 8)) throw new ArgumentOutOfRangeException(nameof(startIdx));
        if (count + startIdx > (Marshal.SizeOf(typeof(T)) * 8)) throw new ArgumentOutOfRangeException(nameof(count));
        return (T)Convert.ChangeType((bits.ToInt64(null) >> startIdx) & ((1 << count) - 1), typeof(T));
    }
    /// <summary>Sets the bit values at the specified range in a bit vector.</summary>
    /// <typeparam name="T">The type of the bit vector. Must be of type <see cref="IConvertible"/>.</typeparam>
    /// <typeparam name="TValue">The type of the value. Must be of type <see cref="IConvertible"/>.</typeparam>
    /// <param name="bits">The bit vector.</param>
    /// <param name="startIdx">The zero-based start index of the bit range to set.</param>
    /// <param name="count">The number of sequential bits to set starting at <paramref name="startIdx"/>.</param>
    /// <param name="value">The value to set within the specified range of <paramref name="bits"/>.</param>
    public static void SetBits<T, TValue>(ref T bits, byte startIdx, byte count, TValue value) where T : IConvertible where TValue : IConvertible
    {
        if (startIdx >= (Marshal.SizeOf(typeof(T)) * 8)) throw new ArgumentOutOfRangeException(nameof(startIdx));
        if (count + startIdx > (Marshal.SizeOf(typeof(T)) * 8)) throw new ArgumentOutOfRangeException(nameof(count));
        var val = value.ToInt64(null);
        if (val >= (1 << count)) throw new ArgumentOutOfRangeException(nameof(value));
        bits = (T)Convert.ChangeType(bits.ToInt64(null) & ~(((1 << count) - 1) << startIdx) | (val << startIdx), typeof(T));
    }
