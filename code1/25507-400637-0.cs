    namespace Foo { 
      namespace System {
        class DateTime {} 
        class Example {
          object Example() { 
            return System.DateTime.Now; // Returns Foo.System.DateTime.Now
            return global::System.DateTime.Now; // Returns mscorlib,System.DateTime.Now
          }
        }
      }
    }
