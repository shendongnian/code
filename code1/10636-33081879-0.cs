    class First : IFirst {
      private BaseClass ContainerInstance;
      First(BaseClass container) { ContainerInstance = container; }
      public void FirstMethod() { Console.WriteLine("First"); ContainerInstance.DoStuff(); } 
    }
    ...
