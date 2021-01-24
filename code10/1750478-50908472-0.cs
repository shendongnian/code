    public static void Main()
    {
        var abc = new List<long>(){ 1,2,3,4};
        var result = abc.AsQueryable().ConvertExtension();
    }
    public static IQueryable ConvertExtension<T>(this IQueryable<T> source, bool condition=false)
    {
        return condition
                    ? (IQueryable) source.Select(x => x.ToString()).AsQueryable<string>()
                       : source.Select(x => int.Parse(x.ToString())).AsQueryable<int>();
    }
