    class BClass<T>
        {
            public static T1 Create<T1, T2>() where T1 : BClass<T2>, new()
            {
                return new T1();
            }
        }
    
        class DClass : BClass<int> { }
    
        class Program
        {
            static void Main(string[] args)
            {
                DClass d = DClass.Create<DClass, int>();
            }
        }
