    class Program
    {
        static void Main()
        {
            date today = new date(7,10,1985);
            date tomoz = new date();
            
            tomorrow = today++; 
    
            tomorrow.Print();  // prints "7/10/1985" i.e. doesn't increment      
            Console.Read();
        }
    }
