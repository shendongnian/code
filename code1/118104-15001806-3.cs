    using System;
    
    namespace ConsoleApplication1
    {
        //I've made this class private to demonstrate that the SaveToDatabase cannot have any knowledge of this Program class.
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
    
            //this is the method which will be delegated - the only thing it has in common with the NofityDelegate is that it takes 0 parameters and that it returns void. However, it is these 2 which are essential
            private static void NotifyIfComplete()
            {
                Console.WriteLine("Notified");
            }
        }
        
    
        public class SaveToDatabase
        {
            public void Start(NotifyDelegate nd)
            {
                Console.WriteLine("Yes, I shouldn't write to the console from here, it's just to demonstrate the code executed.");
                Console.WriteLine("SaveToDatabase Complete");
                Console.WriteLine(" ");
                nd.Invoke();
            }
        }
        public delegate void NotifyDelegate();
    }
