    public static class EnumerationExtensions {
        public static bool Has<T>(this System.Enum type, T value) {
            try {
                return (((int)(object)type & (int)(object)value) == (int)(object)value);
            } 
            catch {
                return false;
            }
        }
        //... etc...
    }
    
    //Then use it like this
    bool hasValue = permissions.Has(PermissionTypes.Delete);
