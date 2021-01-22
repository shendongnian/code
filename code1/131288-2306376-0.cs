    class Program
    {
      class MyClass
      {
         public string value;
         public MyClass(string value) { this.value = value; }
         public bool Contains(char elem)
         {
            Console.WriteLine("Checking if {0} contains {1}", value, elem);
            return value.Contains(elem);
         }
      }
      static void Main(string[] args)
      {
         var mc = new MyClass[2];
         mc[0] = new MyClass("One");
         mc[1] = new MyClass(null);
         var q = from i in mc where i.value == null ? true : i.Contains('O') select i;
         foreach (MyClass c in q)
            Console.WriteLine(c.value == null ? "null" : c.value);
      }
    }
