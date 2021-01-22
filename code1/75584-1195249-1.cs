        public static void DoSomething<T>() where T : ICommon
        {
            //...
        }
        public interface IInterface1 : ICommon
        {}
        public interface IInterface2 : ICommon
        { }
        public interface ICommon
        { }
