    static void Main()    
    {
        .....
        foreach (var retval in GetValues(child1s, 5))
            System.Console.WriteLine(retval);
        foreach (var retval in GetValues(child2s, 5))
            System.Console.WriteLine(retval);
    
        System.Console.ReadKey();
    }
    public static IEnumerable<decimal> GetValues(IEnumerable<Parent> items, decimal calculatedValue)
    {
        foreach (var item in items)
        {
            yield return (decimal)(item.ProductRate * 100 * calculatedValue);
        }
    }
