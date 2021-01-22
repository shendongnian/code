    public class Class
    {
        public void MethodWithoutAspect()
        {
            var dummy = new string('a', 10);
            Console.WriteLine(dummy);
        }
        public void MethodWithAspect()
        {
            Aspect.LogException(() =>
            {
                var dummy = new string('a', 10);
                Console.WriteLine(dummy);
            });
        }
    }
    public static class Aspect
    {
        public static void LogException(Action block)
        {
            try
            {
               block();
            }
            catch (Exception e)
            {
                Log(e);
                throw;
            }
        }
        private static void Log(Exception e)
        {
            throw new NotImplementedException();
        }
    }
