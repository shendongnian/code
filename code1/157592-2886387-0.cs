    public class Foo<T> where T : IComparable<T>
    {
        public static void Bar(T blah, T bloo)
        {
            if(blah.CompareTo(bloo) < 0)    //needs the constraint
                Console.WriteLine("blee!");
        }
    }
