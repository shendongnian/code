An alternative to Mr. Skeet's solution: If we drop the requirement for a linq query and more literally address "convert an IEnumerable&lt;int&gt; to another IEnumerable&lt;int&gt;" we can use this:
    static IEnumerable&lt;int&gt; Sum(IEnumerable&lt;int&gt; a)
    {
        int sum = 0;
        foreach (int i in a)
        {
            sum += i;
            yield return sum;
        }
    }
