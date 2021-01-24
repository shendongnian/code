    public static class Logger
    {
        private static string myID { get; set; }
    
        public static SetMyId(string id)
        {
            myID = id;
        }
    
        public static void Log(string message)
        {
            //print myID _+ message
        }
    }
