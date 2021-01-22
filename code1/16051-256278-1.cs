    static readonly Finalizer finalizer = new Finalizer();
    	
    sealed class Finalizer {
      ~Finalizer() {
        Thread.Sleep(1000);
        Console.WriteLine("one");
        Thread.Sleep(1000);
        Console.WriteLine("two");
        Thread.Sleep(1000);
        Console.WriteLine("three");
        Thread.Sleep(1000);
        Console.WriteLine("four");
        Thread.Sleep(1000);
        Console.WriteLine("five");
      }
    }
