    class Weird {
       public int Prop { get; set; }
    }
    static void Test(ref int x) {
       x = 42;
       throw new Exception();
    }
    static void Main() { 
       int v = 10;
       try {
          Test(ref v);
       } catch {}
       Console.WriteLine(v); // prints 42
       var c = new Weird();
       c.Prop = 10;
       try {
          Test(ref c.Prop);
       } catch {}
       Console.WriteLine(c.Prop); // prints 10!!!
    }
