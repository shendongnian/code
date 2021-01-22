    IAbstract
    {
      void eat();
      void drink();
    }
    
    class This : IAbstract
    {
      void eat() { ... }
      void drink() { ... }
    }
    
    class That : IAbstract
    {
      void eat() { ... }
      void drink() { ... }
    }
