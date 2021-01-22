    public static class UnityExtensions
    {
        public static T TryResolve<T>( this UnityContainer container )
            where T : class
        {
            try
            {
                return (T)container.Resolve( typeof( T ) );
            }
            catch( Exception )
            {
                return null;
            }
        }
    }
