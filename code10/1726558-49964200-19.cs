    using System.Runtime.CompilerServices;
    ...
    public class Callee
    {
        public Callee([CallerFilePath] string callerFileName = "")
        {
            Console.WriteLine(callerFileName);
        }
    }
