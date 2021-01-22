    public static IEnumerable<T> MergeSorted<T>(IEnumerable<IEnumerable<T>> xss) where T :IComparable
    {
        var stacks = xss.Select(xs => new EnumerableStack<T>(xs)).ToList();
    
        while (true)
        {
            if (stacks.All(x => x.IsEmpty)) yield break;
    
            yield return 
                stacks
                    .Where(x => !x.IsEmpty)
                    .Select(x => new { peek = x.Peek(), x })
                    .MinBy(x => x.peek)
                    .x.Pop();
        }
    }
The idea is that we turn each IEnumerable into EnumerableStack that has Peek(), Pop() and IsEmpty members. 
It works just like a regular stack. Note that calling IsEmpty might enumerate wrapped IEnumerable.
