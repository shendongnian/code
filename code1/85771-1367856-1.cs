    public static class OperationsFactory
    {
        public static IOperations CreateOperations()
        {
            A result = new A();
            result.Init();
            return result;
        }
        public static IOperations CreateOperations(int initData)
        {
            B result = new B();
            result.Init(initData);
            return result;
        }
    }
