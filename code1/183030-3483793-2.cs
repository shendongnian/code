    public class Program
    {
        static int _abcd = 1;
    
        static int abcd
        {
            get
            {
                return _abcd; // <--- UPDATE: Notice the semicolon!!!!!!
            }
        } 
    
        static void Main(string[] args)
        {
            Console.WriteLine(abcd);
        }
    }
