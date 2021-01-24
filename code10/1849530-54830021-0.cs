        public class Program
    {
        public class X
        {
            // protected / public
            protected void GetX()
            {
                Console.WriteLine("X");
            }
        }
        public class Y : X
        {
            public void gx()
            {
                GetX();// within class, I can access the method from base class. 
            }
        }
        static void Main(string[] args)
        {
            var y = new Y();
            y.gx();// Works
            y.GetX(); // Not work
            Console.ReadKey();
        }
    }
