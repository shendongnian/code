    public class Bling
    {
        public static void DoBling()
        {
            MyScopedBehavior.Begin(() =>
            {
                //Do something.
            }) ;
        }   
    }
    public static class MyScopedBehavior
    {
        public static void Begin(Action action)
        {
            try
            {
                action();
                //Do additonal scoped stuff as there is no exception.
            }
            catch (Exception ex)
            {
                //Clean up...
                throw;
            }
        }
    }   
