    abstract class Animal {}
    class Tiger : Animal {}
    class Giraffe : Animal {}
    class Cage<T> where T : Animal 
    {
      public T Contents { get; set; }
    }
