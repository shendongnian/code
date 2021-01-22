    public class MyDisposable : IDisposable
    {
        public void Dispose()
        {
            Console.WriteLine("In Dispose");
        }
        public static void MethodOne()
        {
            Console.WriteLine("Method One");
            using (MyDisposable disposable = new MyDisposable())
            {
                try
                {
                    throw new Exception();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("In catch");
                }
            }
        }
        public static void MethodTwo()
        {
            Console.WriteLine("Method Two");
            try
            {
                using (MyDisposable disposable = new MyDisposable())
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("In catch");
            }
        }
        public static void Main()
        {
            MethodOne();
            MethodTwo();
        }
    }
