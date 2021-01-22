     namespace Test {
        class Decimal { }
     }
     // File2.cs
     using Test;
     class DecimalIsNotdecimal {
          void Method(decimal d) { ... }
          void Method(Decimal d) { ... } // works!
     }
