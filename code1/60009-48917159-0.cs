    using System;
    
    namespace TestReadOnly
    {
        class Program
        {
            private readonly int i;
    
    		public Program()
    		{
    			i = 66;
    		}
    
    		private unsafe void ForceSet()
    		{
    			fixed (int* ptr = &i) *ptr = 123;
    		}
    
            static void Main(string[] args)
            {
                var program = new Program();
    			Console.WriteLine("Contructed Value: " + program.i);
    			program.ForceSet();
    			Console.WriteLine("Forced Value: " + program.i);
            }
        }
    }
