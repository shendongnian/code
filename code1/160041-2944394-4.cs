    interface IBase {}
	
    static class Container {
        static class PerType<T> where T : IBase {
            public static IEnumerable<T> list;
        }
        public static IEnumerable<T> Get<T>() where T : IBase 
		    => PerType<T>.list; 
		public static void Set<T>(IEnumerable<T> newlist) where T : IBase 
		    => PerType<T>.list = newlist;
        
		public static IEnumerable<T> GetByExample<T>(T ignoredExample) where T : IBase 
		    => Get<T>(); 
    }
