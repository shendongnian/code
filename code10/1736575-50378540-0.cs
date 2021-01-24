    public class Foo {
        public Foo(int bar, string baz) {
            Bar = bar;
            Baz = baz;
        }
        public int Bar { get; set; } //Read/write property
        public string Baz { get; } //Readonly
        public bool IsFooEven {
           get { return Bar % 2 == 0; } //Calculated property
        }
    }
