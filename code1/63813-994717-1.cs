        class Foo {
            public float Height { get; set; }
        }
        class Bar : Foo {
            public int Height { get; set; }
        }
        class BarBar : Bar { }
        class Foo2 : Foo{
            public float Height { get; set; }
        }
        class BarBar2 : Foo2 { } 
        static void Main(string[] args) {
            // works 
            var p = typeof(BarBar).GetProperty("Height", typeof(float), Type.EmptyTypes);
            // works
            var p2 = typeof(BarBar).BaseType.GetProperty("Height", BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance);
            // works
            var p3 = typeof(BarBar2).GetProperty("Height");
            // fails
            var p4 = typeof(BarBar).GetProperty("Height"); 
            Console.WriteLine(p);
        
        }
