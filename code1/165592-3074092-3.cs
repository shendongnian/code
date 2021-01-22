    namespace MyProject  
    {  
        class MyProject  
        {
            public static Logger Logs = new Logger();
            public static WebServer Web;
    
            static void Main()
            {  
                Web = new WebServer(Logs);
            }  
        }  
    }
