    public class MixedIn : MDoSomething
    {
        public string DoSomethingGreat(string greatness)
        {
             // NB: this is used here.
             return this.DoSomething(greatness) + " is great.";
        }
    }
    public class Program
    {
        public static void Main()
        {
            MixedIn m = new MixedIn();
            Console.WriteLine(m.DoSomething("SO"));
            Console.WriteLine(m.DoSomethingGreat("SO"));
            Console.ReadLine();
        }
    }
