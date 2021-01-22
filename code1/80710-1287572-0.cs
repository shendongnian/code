    public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source, Random rng)
    {
        T[] elements = source.ToArray();
        for (int i=0; i < elements.Length-1; i++)
        {
            // Swap element "i" with a random element above it (or itself)
            int offset = rng.Next(elements.Length - i);
            T tmp = elements[i];
            elements[i] = elements[i + offset];
            elements[i + offset] = tmp;
        }
        // Lazily yield (avoiding aliasing issues etc)
        foreach (T element in elements)
        {
            yield return element;
        }
    }
