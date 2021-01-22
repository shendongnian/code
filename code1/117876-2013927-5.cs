        class Foo {
          public static DoSomething(Bar b) {...}
        }
      
        class Bar {
          public Bar() { Foo.DoSomething(this); }
        }
