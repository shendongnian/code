    public static MethodInfo GetOrderByMethod<TElement, TSortKey>()
    {
        Func<TElement, TSortKey> fakeKeySelector = element => default(TSortKey);
        Expression<Func<IEnumerable<TElement>, IOrderedEnumerable<TElement>>> lamda
            = list => list.OrderBy(fakeKeySelector);
        return (lamda.Body as MethodCallExpression).Method;
    }
    static void Main(string[] args)
    {
        List<int> ints = new List<int>() { 9, 10, 3 };
        MethodInfo mi = GetOrderByMethod<int, string>();           
        Func<int,string> keySelector = i => i.ToString();
        IEnumerable<int> sortedList = mi.Invoke(null, new object[] { ints, 
                                                                     keySelector }
                                               ) as IEnumerable<int>;
        foreach (int i in sortedList)
        {
            Console.WriteLine(i);
        }
    }
