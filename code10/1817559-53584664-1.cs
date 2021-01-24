    class Test {
      public int A {get; set;} = 5;
      public string B {get; set;} = "test";
    
      public Test() {
      }
    
      public Test(int a) {
        this.A = a;
      }
    
      public Test(int a, string b) {
        this.A = a;
        this.B = b;
      }
    }
