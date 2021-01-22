    public class MyRootClass : IOne, ITwo
    {
        private IInterfaceToImplement internalData = new MyConcreteClass();
        public int FunctionOne() { return this.internalData.FunctionOne(); }
        public double FunctionTwo() { return this.internalData.FunctionTwo(); }
    }
