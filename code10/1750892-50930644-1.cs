    public class myHostType	{
        public static void print(string format, params object[] args) {
            Console.WriteLine(format, args);
        }
    }
    ...
    engine.Execute("console.print('Hello {0} {1}', 'World', 42);");
