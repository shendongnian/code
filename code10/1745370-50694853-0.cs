    [Flags]
    enum bla {
      foo = 1,
      bar = 2,
      baz = 4
    }
    public void Foo() {
      bla flag = (bla)3; // Flags foo and bar
      int andBackToInt = (int)flag; // 3
    }
