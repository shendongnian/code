    class Caller
    {
        static void Main(string[] args)
        {
            Callee callee = new Callee();
            List<String> s = new List<String>();
            callee.DoSomething(ref s);
    
            Console.WriteLine(s.Count); // Prints out 0
        }
    }
    public class Callee 
    {
        void DoSomething(ref List<string> list)
        {
            list = new List<string>(); 
            list.Add("Test String 1");
            list.Add("Test String 2");
        }
    }
