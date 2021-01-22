      class A
      {
        public override int GetHashCode()
        {
          Console.WriteLine("base hashcode is: " + base.GetHashCode());
    
          return 1;
        }
      }
    
      class Program
      {
        public static void Main(string[] args)
        {
          A a = new A();
    
          Console.WriteLine("A's hashcode: " + a.GetHashCode());
    
          Console.WriteLine("A's original hashcode: " + RuntimeHelpers.GetHashCode(a));
        }
      }
