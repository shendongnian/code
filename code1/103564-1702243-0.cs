    var dataObject = (IEnumerable<ICommonToBothTypes>)dataArray;
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
