    public sealed class ChromeFactory
    {
        private static readonly object padlock = new object();
    
        ChromeFactory()
        {
        }
    
        public static WebDriver NewInstance
        {
            get
            {
                lock (padlock)
                {
                    return new ChromeDriver();
                }
            }
        }
