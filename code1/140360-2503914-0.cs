       class Program
       {
          static void Main(string[] args)
          {
             Foo foo = new Foo();
             BasePadWI bp = (BasePadWI)foo;
             Console.WriteLine(bp.name);
          }
       }
    
       class BasePadWI {
          public string name = "BasePadWI";
       }
    
       class Foo
       {
          BasePadWI basePadWI = new BasePadWI();
    
          public static implicit operator BasePadWI(Foo foo)
          {
             System.Console.WriteLine("Converted Foo to BasePadWI");
             return foo.basePadWI;
          }
       }
