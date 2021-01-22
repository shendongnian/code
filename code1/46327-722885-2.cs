    public static class TypeHelper
    {
        public static object GetPropertyValue( object obj, string name )
        {
            return obj == null ? null : obj.GetType()
                                           .GetProperty( name )
                                           .GetValue( obj, null );
        }
    }
