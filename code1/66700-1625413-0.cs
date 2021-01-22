        IEnumerable<int> GeneratePrimes(int n)
        {
            var values = new Numbers[n];
            values[0] = Numbers.Prime;
            values[1] = Numbers.Prime;
            for (int outer = 2; outer != -1; outer = FirstUnset(values, outer))
            {
                values[outer] = Numbers.Prime;
                for (int inner = outer * 2; inner < values.Length; inner += outer)
                    values[inner] = Numbers.Composite;
            }
            for (int i = 2; i < values.Length; i++)
            {
                if (values[i] == Numbers.Prime)
                    yield return i;
            }
        }
        int FirstUnset(Numbers[] values, int last)
        {
            for (int i = last; i < values.Length; i++)
                if (values[i] == Numbers.Unset)
                    return i;
            return -1;
        }
        enum Numbers
        {
            Unset,
            Prime,
            Composite
        }
