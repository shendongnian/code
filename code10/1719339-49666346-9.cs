    public static IEnumerable<int> DistinctUntilChanged(this IEnumerable<int> source)
    {
        int? previous=null;
        foreach(var item in source)
        {
            if (item!=previous)
            {
                previous=item;
                yield return item;
            }
        }
    }
    var input = new [] {1,2,3,3,4,5,5,5,6,6,5,4,4,3,2,1,6};
    var result=input.DistinctUntilChanged().ToArray();
