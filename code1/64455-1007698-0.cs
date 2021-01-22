        public static void Main()
        {
            int i = 1;
            Method1(i); //i here is still 1
            Method2(ref i); //i is now 2
            SimpleObj obj = new SimpleObj();
            obj.Value = 1;
            Method3(obj); //obj.Value now 2
            Method4(obj); // obj.Value still 2
            Method5(ref obj); //obj.Value now 5
        }
        private static void Method5(ref SimpleObj obj)
        {
            obj = new SimpleObj();
            obj.Value = 5;
        }
        private static void Method4(SimpleObj obj)
        {
            obj = new SimpleObj();
            obj.Value = 5;
        }
        private static void Method3(SimpleObj obj)
        {
            obj.Value++;
        }
        private static void Method2(ref int i)
        {
            i++;
        }
        private static void Method1(int i)
        {
            i++;
        }
        public class SimpleObj
        {
            public int Value { get; set; }
        }
