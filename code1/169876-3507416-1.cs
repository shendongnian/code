        public static bool IsNullOrEmpty(String value) {
            return (value == null || value.Length == 0); 
        }
        public static bool IsNullOrWhiteSpace(String value) {
            if (value == null) return true; 
            for(int i = 0; i < value.Length; i++) { 
                if(!Char.IsWhiteSpace(value[i])) return false; 
            }
 
            return true;
        }
