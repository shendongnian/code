    static class TestDab
    {
        public static void PrintTwo(int a, int b) {
            Console.WriteLine("{0} {1}", a, b);
            Trace.WriteLine(string.Format("{0} {1}", a, b));//for immediate window.
        }
        public static void PrintHelloWorld() {
            Console.WriteLine("Hello World!");
            Trace.WriteLine("Hello World!");//for immediate window.
        }
        public static void TestIt() {
            var dynFunc = DynamicActionBuilder.MakeAction(null,
                typeof(TestDab).GetMethod("PrintTwo"));
            dynFunc(3, 4);
            var dynFunc2 = DynamicActionBuilder.MakeAction(null,
                typeof(TestDab).GetMethod("PrintHelloWorld"));
            dynFunc2("extraneous","params","allowed"); //you may want to check this.
        }
    }
