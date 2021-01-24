    static void Main()
    {
        List<Child1> child1s = new List<Child1>()
        {
            new Child1() { Name="c11", ProductRate=1},
            new Child1() { Name="c12", ProductRate=2}
        };
    
        List<Child2> child2s = new List<Child2>()
        {
            new Child2() { Name="c21", ProductRate=30},
            new Child2() { Name="c21", ProductRate=60}
        };
    
        foreach (var retval in GetValues(child1s, 5))
            System.Console.WriteLine(retval);
        foreach (var retval in GetValues(child2s, 5))
            System.Console.WriteLine(retval);
    
        System.Console.ReadKey();
    }
    public static IEnumerable<decimal> GetValues<T>(List<T> items, decimal calculatedValue) where T : Parent
    {
        foreach (var item in items)
        {
            yield return (decimal)(item.ProductRate * 100 * calculatedValue);
        }
    }
