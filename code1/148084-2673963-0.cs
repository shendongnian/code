    public static class NullableMixin {
        public static bool IsTrue(this System.Nullable<bool> val) {
            return val ?? false;
        }
        public static bool IsFalse(this System.Nullable<bool> val) {
            return !val ?? false;
        }
        public static bool IsNull(this System.Nullable<bool> val) {
            return !val.HasValue
        }
        public static bool IsNotNull(this System.Nullable<bool> val) {
            return val.HasValue
        }
    }
    
    
    Nullable<bool> value = null;
    if(value.IsTrue())
     ... 
