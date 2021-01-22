     public static class TryParseGeneric
        {
            //extend int
            public static dynamic TryParse<T>( this string input )
            {    
                dynamic runner = new StaticMembersDynamicWrapper( typeof( T ) );
    
                T value;
                bool isValid = runner.TryParse( input, out value );
                return new { IsValid = isValid, Value = value };
            }
        }
    
        public class StaticMembersDynamicWrapper : DynamicObject
        {
            private readonly Type _type;
            public StaticMembersDynamicWrapper( Type type ) { _type = type; }
    
            // Handle static properties
            public override bool TryGetMember( GetMemberBinder binder, out object result )
            {
                PropertyInfo prop = _type.GetProperty( binder.Name, BindingFlags.FlattenHierarchy | BindingFlags.Static | BindingFlags.Public );
                if ( prop == null )
                {
                    result = null;
                    return false;
                }
    
                result = prop.GetValue( null, null );
                return true;
            }
    
            // Handle static methods
            public override bool TryInvokeMember( InvokeMemberBinder binder, object [] args, out object result )
            {
                var methods = _type
                .GetMethods( BindingFlags.FlattenHierarchy | BindingFlags.Static | BindingFlags.Public ).Where( methodInfo => methodInfo.Name == binder.Name );
    
                var method = methods.FirstOrDefault();
    
                if ( method == null )
                {
                    result = null;
    
                    return false;
                }
    
                result = method.Invoke( null, args );
    
                return true;
            }
        }
