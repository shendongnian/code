    class Program
    {
        public class MyClass
        {
            public string MyString { get; set; }
        }
        static void Main()
        {
            int  i1 = 1;    Test("i1", i1); // False
            int  i2 = 0;    Test("i2", i2); // True
            int? i3 = 2;    Test("i3", i3); // False
            int? i4 = null; Test("i4", i4); // True
            Console.WriteLine();
            string s1 = "hello";      Test("s1", s1); // False
            string s2 = null;         Test("s2", s2); // True
            string s3 = string.Empty; Test("s3", s3); // True
            string s4 = "";           Test("s4", s4); // True
            Console.WriteLine();
            MyClass mc1 = new MyClass(); Test("mc1", mc1); // False
            MyClass mc2 = null;          Test("mc2", mc2); // True
        }
        public static void Test<T>(string fieldName, T field)
        {
            Console.WriteLine(fieldName + ": " + IsNullOrEmpty(field));
        }
        // public static bool IsNullOrEmpty<T>(T value) ...
        // public static bool IsNull<T>(T value) ...
    }
