    class Program
    {
        static void Main( string[] args )
        {
            try
            {
    
                using( MyDisposable x = new MyDisposable () )
                {
                        throw new InvalidOperationException ("An error occured");
                }
            }
            catch
            {
                Console.WriteLine ("Exception caught");
            }
    
            Console.ReadLine ();
    
              
        }
        
        public class MyDisposable : IDisposable
        {
            public void Dispose()
            {
                Console.WriteLine ("Dispose is called");
            }
        }
