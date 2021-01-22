    protected Singleton()
    {
        Console.WriteLine("Singleton constructor");
    }
        private static readonly Singleton INSTANCE;
        static Singleton() {
            try {
               INSTANCE = new Singleton();
            }
            catch(Exception e) {
                throw new Exception();
            }
        }
