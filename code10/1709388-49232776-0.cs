    public class Program
    {
        private static readonly AsyncLocal<string> AsyncLocalContext = new AsyncLocal<string>();
        
        public static void Main(string[] args)
        {
            AsyncLocalContext.Value = "No surprise";
            WrapperAsync("surprise!");
            Console.WriteLine("Main: " + AsyncLocalContext.Value);
        }
        
        private static async void WrapperAsync(string text)
        {
            Console.WriteLine("WrapperAsync before: " + AsyncLocalContext.Value);
            AsyncLocalContext.Value = text;
            Console.WriteLine("WrapperAsync after: " + AsyncLocalContext.Value);
        }
    }
