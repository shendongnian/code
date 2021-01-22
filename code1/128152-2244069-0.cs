    public class Class
    {
        public string MethodWithoutAspect()
        {
            var dummy = new string( 'a', 10 );
            Console.WriteLine(dummy);
            return dummy;
        }
        public string MethodWithAspect()
        {
            return Aspects.LogException(() =>
            {
                var dummy = new string('a', 10);
                Console.WriteLine(dummy);
                return dummy;
            });
        }
    }
    public static class Aspects
    {
        public static T LogException<T>(Func<T> method)
        {
            try
            {
               return method();
            }
            catch ( Exception e )
            {
                Log( e );
                throw;
            }
        }
        private static void Log( Exception e )
        {
            throw new NotImplementedException();
        }
    }
