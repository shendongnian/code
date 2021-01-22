    public class ExceptionHandler
    {
        public static bool HandleException(Exception ex, IList<Param> parameters)
        {
            /*
             * Log the exception
             * 
             * Return true to rethrow the original exception,
             * else false
             */
        }
    }
    public class Param
    {
        public string Name { get; set; }
        public object Value { get; set; }
    }
    public class MyClass
    {
        public void RenderSomeText(int lineNumber, string text, RenderingContext context)
        {
            try
            {
                /*
                 * Do some work
                 */
                throw new ApplicationException("Something bad happened");
            }
            catch (Exception ex)
            {
                if (ExceptionHandler.HandleException(
                        ex, 
                        new List<Param>
                        {
                            new Param { Name = "lineNumber", Value=lineNumber },
                            new Param { Name = "text", Value=text },
                            new Param { Name = "context", Value=context}
                        }))
                {
                    throw;
                }
            }
        }
    }
