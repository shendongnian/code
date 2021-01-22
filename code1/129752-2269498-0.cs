    public class MyDto {
        public string A {get;set;}
        public string B {get;set;}
        public string C {get;set;}
        public string D {get;set;}
        public FooUnited GetObject() {
            return new FooUnited {
                foo1 = new Foo1 { A = this.A, B = this.B },
                foo2 = new Foo2 { C = this.C, D = this.D },
            };
        }
    }
