    class Program
    {
        static void Main(string[] args)
        {
            Methoddef md=new Methoddef();
            DelDec.Initdel d = md.process; //you create variable of delegate type Initdel and asign this variable
    
            var obj = new DelDec();
            obj.Init = d; //assign delegate to class instance
    
            obj.Init("Test");
    
        }
    
        public class DelDec
        {
            //Declares a delegate for a void method that takes an string parameter.
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
