    class TestHelper
    {
        public static Metrics Metrics { get; private set; }
    
        static TestHelper
        {
            string path = GetPath();
            bool option = GetOption();
            Metrics = new Metrics(path, option);
        }
        
    }
