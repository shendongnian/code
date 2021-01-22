    using System;
    
    namespace ConsoleApplication1
    {
        /* I've made this class private to demonstrate that 
        * the SaveToDatabase cannot have any knowledge of this Program class.
        */
        class Program
        {
            static void Main(string[] args)
            {
                //Note, this NotifyDelegate type is defined in the SaveToDatabase project
                NotifyDelegate nofityDelegate = new NotifyDelegate(NotifyIfComplete);
    
                SaveToDatabase sd = new SaveToDatabase();            
                sd.Start(nofityDelegate);
                Console.ReadKey();
            }
    
            /* this is the method which will be delegated -
             * the only thing it has in common with the NofityDelegate
             * is that it takes 0 parameters and that it returns void.
             * However, it is these 2 which are essential.
             * It is really important to notice that it writes
             * a variable which, due to no constructor,
             * has not yet been called (so _notice is not initialized yet).
             */ 
        private static void NotifyIfComplete()
        {
            Console.WriteLine(_notice);
        }
        private static string _notice = "Notified";
        }
        
    
        public class SaveToDatabase
        {
            public void Start(NotifyDelegate nd)
            {
                /* I shouldn't write to the console from here, 
                 * just for demonstration purposes
                 */
                Console.WriteLine("SaveToDatabase Complete");
                Console.WriteLine(" ");
                nd.Invoke();
            }
        }
        public delegate void NotifyDelegate();
    }
