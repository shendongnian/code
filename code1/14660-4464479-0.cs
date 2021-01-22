    [Serializable]
    class Foo {
        public Bar MyBar { get; set; }
    }
    [Serializable]
    class Bar {
        int x;
    }
    class DerivedBar {
    }
    public void TestSerializeFoo() {
        Serialize(new Foo()); // OK
        Serialize(new Foo() { MyBar = new Bar() }; // OK
        Serialize(new Foo() { MyBar = new DerivedBar() }; // Boom
    }
