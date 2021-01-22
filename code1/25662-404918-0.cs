    class Program
        {
            void Main()
            {
                VoidFunction t = RealFunction;
                int i = 1;
            }
            delegate void VoidFunction();
            void RealFunction() { int i = 0; }
        } 
