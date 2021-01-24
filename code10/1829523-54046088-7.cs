        using System.Linq; //woops
        namespace Charlie {
            class C {
                void Foo() {
                    var l = new List<object>() { 1, 2, 3 };
                    var m = l.Max() /*compile time error. Ambiguous call*/ } }
        }
