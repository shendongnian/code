    namespace ExtensionMethods
    {
        public static class MyExtensions
        {
            public static string GetName(this Player p) 
            { 
                return p.Name?.ToString(); 
            }
            public static int GetId(this Player p) 
            { 
                return Convert.ToInt32(p.Id);
            }
        }   
    }
