    public class ComplexParams : IParams
    {
        public IEnumerable<IBar> Params { get; }
        public ComplexParams(IEnumerable<IBar> complexParams)
        {
            Params = complexParams;
        }
    }
    public class SimpleParams : IParams
    {
        public IEnumerable<IBar> Params { get; }
        public SimpleParams(IEnumerable<IBar> simpleParams)
        {
            Params = simpleParams;
        }
    }
