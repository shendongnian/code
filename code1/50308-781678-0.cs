    public Adder Add(params int[] i) { /* ... */ }
    public Adder Remove(params int[] i) { /* ... */ }
    Adder adder = new Adder()
      .Add(1, 2, 3)
      .Remove(3, 4);
