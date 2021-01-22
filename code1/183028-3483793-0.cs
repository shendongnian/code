    public class Program
    {
        static int _abcd = 1;
    
        static int abcd
        {
            get
            {
                return _abcd;
            }
        } 
    
        static void Main(string[] args)
        {
            Console.WriteLine(abcd);
        }
    }
