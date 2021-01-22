      public class Test
      {
        Action _showValue;
    
        public void Run()
        {
          string local = "Initial";
          _showValue = () => { Console.WriteLine(local.ToString()); };
    
          Console.WriteLine("Passing by value");
          inMethod(local);
          Console.WriteLine("Passing by reference with 'out' keyword");
          outMethod(out local);
          Console.WriteLine("Passing by reference with 'ref' keyword");
          refMethod(ref local);
    
        }
    
        void inMethod(string arg)
        {
          _showValue();
          arg = "IN";
          _showValue();
        }
    
        void outMethod(out string arg)
        {
          _showValue();
          arg = "OUT";
          _showValue();
        }
    
        void refMethod(ref string arg)
        {
          _showValue();
          arg = "REF";
          _showValue();
        }
      }
