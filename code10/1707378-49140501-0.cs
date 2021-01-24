    using System;
    using System.ComponentModel; 
    
    public class Program
    {
        public static void Main(string[] args)
        {
            C1 c1 = new C1();
            L1 l1 = new L1();
            L2 l2 = new L2();
            try
            {
                c1.Raise(); // will crash
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
    
            c1.Raise2(); // safe
    
            l1.AddListener(c1);
            c1.Raise();
            l2.AddListener(c1); // more then 1 listener possible
            c1.Raise();
    
            Console.ReadLine();
        }
    
        public class C1 : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
    
            public void Raise()
            {
                // no ?. -> Exception if handler not set
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(DateTime.Now.ToString()));
            }
    
            public void Raise2()
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
