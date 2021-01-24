    public class ComplexParam : IParam
    {
        public IEnumerable<IBar> Param { get; }
        public ComplexParam(IEnumerable<IBar> complexParam)
        {
            Param = complexParam;
        }
    }
    public class SimpleParam : IParam
    {
        public IEnumerable<IBar> Param { get; }
        public SimpleParam(IEnumerable<IBar> simpleParam)
        {
            Param = simpleParam;
        }
    }
