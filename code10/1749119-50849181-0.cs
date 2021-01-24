    private static readonly List<int> nums = new List<int> { 1, 2, 3 };
    public static IEnumerable<int> MyEach(this IEnumerable<int> enumeration, Action<int> action)
    { 
        foreach (var item in enumeration)
        {
            action(item);
            yield return item;
        }
    }
