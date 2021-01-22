    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (OtherClass inner = new OtherClass())
                {
                    Console.WriteLine("Everything is fine");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.Read();
        }
    }
    class OtherClass : IDisposable
    {
        public OtherClass()
        {
            throw new Exception("Some Error!");
        }
        void IDisposable.Dispose()
        {
            Console.WriteLine("I've disposed my resources");
        }
    }
