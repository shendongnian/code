    public sealed class Singleton
    {
        private static readonly Singleton instance = new Singleton();
 
        static Singleton()
        {
        }
 
        private Singleton()
        {
        }
 
        /// <summary>
        /// The public Instance property to use
        /// </summary>
        public static Singleton Instance
        {
            get { return instance; }
        }
    }
