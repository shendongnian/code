    enum Color { Red }
    class C { 
      public Color Color { get; private set; }
      public void M(Color c) { }
      public void N(String s) { }
      public void O() {
        M(Color.Red);
        N(Color.ToString());
      }
    }
