    abstract class SomeBase { // think: AbstractProcessDataObject
        public abstract void Process();
    }
    class Foo : SomeBase {
        public override void Process() { /* do A */ }
    }
    class Bar : SomeBase {
        public override void Process() { /* do B */ }
    }
    SomeBase obj = new Foo();
    obj.Process();
