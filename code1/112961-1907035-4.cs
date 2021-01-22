    public delegate int SomeDelegate1(int p);
    public delegate int SomeDelegate2(int p);
    ...
      SomeDelegate1 a = new SomeDelegate1(Inc);
      SomeDelegate2 b = (SomeDelegate2)a;  // CS0030
