    class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Hello World!");
    
                var cl = new Class1();
                cl.PropertyChanged += propertyChanged;
    
                cl.SetProperty(nameof(cl.MyProp), 1);
                Console.ReadLine();
            }
    
            private static void propertyChanged(object sender, PropertyChangedEventArgs e)
            {
                Console.WriteLine (e.PropertyName);
    
            }
        }
