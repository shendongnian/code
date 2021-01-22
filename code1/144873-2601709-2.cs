    private static IEnumerable<T> pairSwitch<T>(IEnumerable<T> sequence)
    {
        using(IEnumerator<T> enumerator = sequence.GetEnumerator())
        {
            bool swap = true;
            while (enumerator.MoveNext())
            {
                T first = enumerator.Current;
                if (enumerator.MoveNext())
                {
                    if (swap)
                    {
                        yield return enumerator.Current;
                        yield return first;
                    }
                    else {
                        yield return first;
                        yield return enumerator.Current;
                    }
                    swap = !swap;
                }
            }
        }
    }
