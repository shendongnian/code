    namespace MyProject  
    {  
        class MyProject  
        {
            public Logger Logs = new Logger();
            public WebServer Web;
    
            static void Main()
            {  
                Web = new WebServer(Logs);
            }  
        }  
    }
