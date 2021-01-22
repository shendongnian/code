    interface IFooFactory {
        FatherClass Create(string val1, string val2);
    }
    class ChildClassFactory : IFooFactory
    {
        public FatherClass Create(string val1, string val2) {
            return new ChildClass(val1, val2);
        }
    }
