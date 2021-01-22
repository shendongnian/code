    class Repository 
    { 
        public static Rep[] rep = new Rep[6]; 
    }
    public struct RepositoryItem
    {
        public string main; 
        public string clean; 
        public int curParCount; 
        public int totalCount; 
        public int parStart; 
        public int partialStart; 
        public double scrollPos; 
        public int selectionStart; 
        public int selectionEnd; 
        public string[] status; 
    }
