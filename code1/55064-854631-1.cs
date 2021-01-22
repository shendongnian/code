    static T[] CopyEvenly<T>(T[] source, int size)
    {
        if (size >= source.Length)
            // or copy it to a new one if you prefer
            return source;
        T[] ret = new T[size];
        // keep everything in doubles
        double factor = (double)(source.Length - 1) / (double)(size - 1);
        for (int i = 0; i < ret.Length; i++)
        {
            // cast to int just now
            int inputIndex = (int)((double)i * factor);
            ret[i] = source[inputIndex];
        }
        return ret;
    }
