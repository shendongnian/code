    public class TryAgain
    {
        public delegate void CodeToTryAgain ();
    
        public static void Repeat<E>(int count, CodeToTryAgain code) where E : Exception
        {
            while (count-- > 0)
            {
                try
                {
                    code();
                    return;
                }
                catch (E ex)
                {
                    Console.WriteLine("Caught an {0} : {1}", typeof(E).Name, ex.Message);
                    // ignoring it!
                }
            }
        }
    }
