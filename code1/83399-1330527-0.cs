    public static IEnumerator<int> Range(int from, int to)
    {
        for (int i = from; i < to; i++)
        {
            yield return i;
        }
    }
