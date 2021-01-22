    package {
     class A {
      private var a:int;
      public function A(a:int) {
       this.a = a;
      }
      // ... probably some meaningful methods here :)
     }
    }
    package {
     class B extends A {
      private var b:int;
      public function B(a:int, b:int) {
       super(a);
       this.b = b;
      }
      // ... probably some other meaningful methods here as well :D
     }
    }
