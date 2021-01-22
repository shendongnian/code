    static T[] CopyEvenly<T>(T[] source, int size)
    {
        if (size >= source.Length)
            // or copy it to a new one if you prefer
            return source;
        T[] ret = new T[size];
        // keep everything in doubles (you can cache this factor here)
        double factor = (double)(source.Length + 1) / (double)size;
        for (int i = 0; i < ret.Length; i++)
        {
            // Math.Round to get the right approximation
            int inputIndex = (int)Math.Round(i * factor);
            ret[i] = source[inputIndex];
        }
        return ret;
    }
