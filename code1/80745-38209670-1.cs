    /// <summary>
    /// Shuffles the elements of a sequence randomly.
    /// </summary>
    /// <param name="source">A sequence of values to shuffle.</param>
    /// <param name="rng">An instance of a random number generator.</param>
    /// <param name="data">A placeholder to generate random bytes into.</param>
    /// <returns>A sequence whose elements are shuffled randomly.</returns>
    public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source, RNGCryptoServiceProvider rng, byte[] data)
    {
        var elements = source.ToArray();
        for (int i = elements.Length - 1; i >= 0; i--)
        {
            rng.GetBytes(data);
            var swapIndex = BitConverter.ToUInt32(data, 0) % (i + 1);
            yield return elements[swapIndex];
            elements[swapIndex] = elements[i];
        }
    }
