    private static string CommaQuibble(IEnumerable<string> input)
    {
        var val = string.Concat(input.Process(
            p => p,
            p => string.Format(" and {0}", p),
            p => string.Format(", {0}", p)));
        return string.Format("{{{0}}}", val);
    }
    public static IEnumerable<T> Process<T>(this IEnumerable<T> input, 
        Func<T, T> firstItemFunc, 
        Func<T, T> lastItemFunc, 
        Func<T, T> otherItemFunc)
    {
        //break on empty sequence
        if (!input.Any()) yield break;
    
        //return first elem
        var first = input.First();
        yield return firstItemFunc(first);
    
        //break if there was only one elem
        var rest = input.Skip(1);
        if (!rest.Any()) yield break;
    
        //start looping the rest of the elements
        T prevItem = first;
        bool isFirstIteration = true;
        foreach (var item in rest)
        {
            if (isFirstIteration) isFirstIteration = false;
            else
            {
                yield return otherItemFunc(prevItem);
            }
            prevItem = item;
        }
    
        //last element
        yield return lastItemFunc(prevItem);
    }
