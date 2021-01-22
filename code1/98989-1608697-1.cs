    public void Gotcha<T>(T value) {
      Example.Method(value);
    }
    
    Gotcha(42);  // Still calls Example.Method<T>()
  
