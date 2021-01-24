    class Program
    {
        class X
        {
            // protected / public
            internal void GetX()
            {
                Console.WriteLine("X");
            }
            protected void GetZ()
            {
                Console.WriteLine("Z");
            }
        }
        class Y : X
        {
            public void GetXZ()
            {
                GetX();// within class, I can access Internal method from base class. 
                GetZ();// within class, I can access Protected method from base class. 
            }
        }
        static void Main(string[] args)
        {
            var y = new Y();
            y.GetX(); // Works
            y.GetZ(); //Does Not Work (Protected method, can't be accessed outside of a derived class)
            y.GetXZ();// Works
            Console.ReadKey();
        }
    }
