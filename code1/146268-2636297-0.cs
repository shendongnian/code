    class Program
    {
        static void Main(string[] args)
        {
            FileSystemWatcher watcher = new FileSystemWatcher("yourpath");
    
            var configurations = new IConfiguration[]
                                     {
                                         new IntConfiguration(20),
                                         new StringConfiguration("Something to print")
                                     };
    
            foreach(var config in configurations)
                watcher.Created += config.HandleCreation;
        }
    
        private interface IConfiguration
        {
            void HandleCreation(object sender, FileSystemEventArgs e);
        }
       
        private class IntConfiguration : IConfiguration
        {
            public IntConfiguration(int aSetting)
            {
                ASetting = aSetting;
            }
    
            private int ASetting { get; set; }
            
            public void HandleCreation(object sender, FileSystemEventArgs e)
            {
                Console.WriteLine("Consume your settings: {0}", ASetting);
            }
        }
    
         public class StringConfiguration : IConfiguration
        {
            public string AnotherSetting { get; set;}
    
            public StringConfiguration(string anotherSetting)
            {
                AnotherSetting = anotherSetting;
            }
    
            public void HandleCreation(object sender, FileSystemEventArgs e)
            {
                Console.WriteLine("Consume your string setting: {0}", AnotherSetting);
            }
        }
    }
