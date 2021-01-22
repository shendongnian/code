    class Program
        {
            static void Main(string[] args)
            {
                TestClass t = new TestClass();
                Console.WriteLine(t is TestGeneric<int>);
                Console.WriteLine(t is TestGeneric<double>);
                Console.ReadKey();
            }
        }
    
    interface TestGeneric<T>
        {
            T myProperty { get; set; }
        }
    
        class TestClass : TestGeneric<int>
        {
            #region TestGeneric<int> Members
    
            public int myProperty
            {
                get
                {
                    throw new NotImplementedException();
                }
                set
                {
                    throw new NotImplementedException();
                }
            }
    
            #endregion
        }
