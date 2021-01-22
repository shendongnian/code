    public class Test
    {
        static void Main()
        {
            Console.WriteLine("'{0}'", "foo bar baz".SmartTrim(20));
            Console.WriteLine("'{0}'", "foo bar baz".SmartTrim(3));
            Console.WriteLine("'{0}'", "foo bar baz".SmartTrim(4));
            Console.WriteLine("'{0}'", "foo bar baz".SmartTrim(5));
            Console.WriteLine("'{0}'", "foo bar baz".SmartTrim(7));
        }
    }
