    public static class StringExtensionHelper {
        public static object ToDbValue( this object value ) {
             object ret = object.ReferenceEquals( value, null ) ? (object)DBNull.Value : value;
             return ret;
        }
    }
