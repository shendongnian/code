    void YourMethod(IEnumerable<ICommonToBothTypes> sequence)
    {
        foreach (var item in sequence)
        {
            Console.WriteLine(item.CommonProperty);
        }
    }
    // ...
    interface ICommonToBothTypes
    {
        string CommonProperty { get; }
    }
    class FirstType : ICommonToBothTypes
    {
        public string CommonProperty
        {
            get { return "Number One"; }
        }
    }
    class SecondType : ICommonToBothTypes
    {
        public string CommonProperty
        {
            get { return "Number Two"; }
        }
    }
