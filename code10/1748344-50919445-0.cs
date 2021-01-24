    static void Main(string[] args)
        {
            AppDomain.CurrentDomain.FirstChanceException +=
            (object source, FirstChanceExceptionEventArgs e) =>
            {
                Console.WriteLine("FirstChanceException event raised in {0}: {1}",
                    AppDomain.CurrentDomain.FriendlyName, e.Exception.Message);
            };
            try
            {
                Console.WriteLine("Doing stuff");
                throw new ArgumentNullException("Super awesome exception");
            }
            catch (Exception e)
            {
                Console.WriteLine("Caught an exception {0}", e.Message);
            }
        }
