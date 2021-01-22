    public static IEnumerable<int> SumIntLists( 
        this IEnumerable<int> first, 
        IEnumerable<int> second) 
    {
        using(var enumeratorA = first.GetEnumerator()) 
        using(var enumeratorB = second.GetEnumerator()) 
        { 
            while (enumeratorA.MoveNext()) 
            {
                if (enumeratorB.MoveNext())
                    yield return enumeratorA.Current + enumeratorB.Current;
                else
                    yield return enumeratorA.Current;
            }
            // should it continue iterating the second list?
            while (enumeratorB.MoveNext())
                yield return enumeratorB.Current;
        } 
    } 
