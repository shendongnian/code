     static void Main(string[] args)
     {
         Foo foo = GetFoo();
   
         if (foo != null && foo is Foo i)
         {
             // Use of unassigned local variable i
             // Local variable 'i' might not be initialized before accessing 
             Console.WriteLine(i);
         }
     }
     static Foo GetFoo() => new Foo();
