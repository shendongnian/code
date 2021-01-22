    public class Foo
    {
        public void Test()
        {
            Console.WriteLine(this == null);
        }
        public static bool operator ==(Foo a, Foo b)
        {
            return true;
        }
        public static bool operator !=(Foo a, Foo b)
        {
            return true;
        }
    }
