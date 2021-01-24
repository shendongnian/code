    using System;
    using System.ComponentModel; 
    
    public class Program
    {
        public static void Main(string[] args)
        {
            C1 c1 = new C1();  // create instance of class that raises event 
            L1 l1 = new L1();  // create instance of 1st class that handles event
            L2 l2 = new L2();  // create instande of 2nd class that handles event
            // no handlers are yet registered on the event
            try
            {
                c1.Raise(); // will crash and output exception as no handler set yet
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
    
            c1.SafeRaise(); // safe, will print message
    
            l1.AddListener(c1); // add as listener 
            c1.Raise();         // prints message
   
            l2.AddListener(c1); // add 2nd listener
            c1.Raise();         // both print message
    
            Console.ReadLine(); // stop console from closing
        }
        
        // Has the prop-changed and 2 raise-methods, 1 safe, 1 not.
        public class C1 : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
    
            // unsafe - will throw if not yet any listerer registered
            public void Raise()
            {
                // no ?. -> Exception if handler not set
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(DateTime.Now.ToString()));
            }
    
            // safe, even if no listener registered.
            public void SafeRaise()
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(DateTime.Now.ToString()));
                Console.WriteLine("PropertyHandlerNotSet! - but safe due to ' PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(DateTime.Now.ToString()));' ");
            }
        }
    
        public class L1
        {
            public void AddListener(C1 c)
            {
                c.PropertyChanged += this.Handler;
            }
    
            public void Handler(object sender, PropertyChangedEventArgs e)
            {
                Console.WriteLine("L1: " + e.PropertyName);
            }
        }
    
        public class L2
        {
            public void AddListener(C1 c)
            {
                c.PropertyChanged += this.Handler;
            }
    
            public void Handler(object sender, PropertyChangedEventArgs e)
            {
                Console.WriteLine("L2: " + e.PropertyName);
            }
        }
    }
