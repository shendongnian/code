    class Program
    {
        static void Main(string[] args)
        {
            var z = 0;
            var a = 0.AsDefaultFor(() => 1 / z);
            Console.WriteLine(a);
            Console.ReadLine();
        }
    }
    public static class TryExtensions
    {
        public static T AsDefaultFor<T>(this T @this, Func<T> operation)
        {
            try
            {
                return operation();
            }
            catch
            {
                return @this;
            }
        }
    }
