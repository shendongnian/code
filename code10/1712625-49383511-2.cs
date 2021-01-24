    class App
    {
        public static void Main(string[] args)
        {
            // Instantiate actors
            Updater updater = new Updater();
            Stopper stopper = new Stopper(updater);
            // Wait for the actors to expire
            updater.Wait();
            stopper.Wait();
            Console.WriteLine("Graceful exit");
        }
    }
