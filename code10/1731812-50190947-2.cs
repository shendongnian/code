    public class Program
    {
        public static void Main()
        {
            var one = new SomeClass { First = 1, Second = 5 };
            var two = new SomeClass { First = 5, Second = 1 };
            string field = "First";
            if (GetValue(one, field) < GetValue(two, field))
            {
                Console.WriteLine("one is smaller than two");
            }
            else
            {
                Console.WriteLine("one is greater than two");
            }
        }
        private static int GetValue(SomeClass someClass, string field) => Convert.ToInt32(typeof(SomeClass).GetProperty(field).GetValue(someClass));
    }
    public class SomeClass
    {
        public int First { get; set; }
        public int Second { get; set; }
    }
