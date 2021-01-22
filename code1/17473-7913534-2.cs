    public static IEnumerable<T> Shuffle<T>(this IList<T> list)
    {
        var choices = Enumerable.Range(0, list.Count).ToList();
        var rng = new Random();
        for(int n = choices.Count; n > 1; n--)
        {
            int k = rng.Next(n);
            yield return list[choices[k]];
            choices.RemoveAt(k);
        }
        yield return list[choices[0]];
    }
