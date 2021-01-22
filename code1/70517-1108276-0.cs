    namespace Bar {
      class Gnat { }
    }
    namespace Foo {
      namespace Bar {
        class Gnat { }
      }
      class Gnus {
        Bar.Gnat a; // Foo.Bar.Gnat
        global::Bar.Gnat b; // Bar.Gnat
      }
    }
