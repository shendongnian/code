    class Program
    {
        static void Main(string[] args)
        {
            Methoddef md=new Methoddef();
            DelDec.Initdel d = md.process; //you create variable of delegate type Initdel and asign this variable
    
            var delDec1 = new DelDec();
            delDec1.Init = d; //assign delegate to class instance
    
            delDec1.Init("Test");
    
        }
    
        public class DelDec
        {
            //Declares a delegate for a void method that takes in an string.
            public delegate void Initdel(String s);
            public Initdel Init;
        }
            
    
        public class Methoddef
        {
            public void process(string s)
            {
                Console.WriteLine("The message passed is " + s);
            }
        }
    }
