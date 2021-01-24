    public static class Container {
        private static AsyncLocal<int> current = new AsyncLocal<int>();
    
        public static int CallId { 
            get {
                return current.Value;
            } 
            set {
                current.Value = value;
            }
        }
    }
