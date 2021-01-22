    private static IEnumerable<int> get_miss(List<int> list,int length)
    {
        var miss = new List<int>();
        int i =0;
        for ( i = 0; i < list.Count - 1; i++)
        {
            foreach (var item in 
                         Enumerable.Range(list[i] + 1, list[i + 1] - list[i] - 1))
            {
                yield return item;
            }
            
        }
        foreach (var item in Enumerable.Range(list[i]+1,length-list[i]))
        {
            yield return item;
        }
    }
