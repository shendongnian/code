    public class Caller
    {
        public Caller()
        {
            new Callee("Caller.cs");
        }
    }
    public class Callee
    {
        public Callee(string callerFileName = "")
        {
            Console.WriteLine(callerFileName );
            Console.ReadKey();
        }
    }
