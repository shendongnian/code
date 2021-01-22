    class FooAndBar {
        Foo _foo;
        Bar _bar;
        public FooAndBar(Foo foo, Bar bar) {
            _foo = foo;
            _bar = bar;
        }
        public void Frobber() { _foo.Frobber(); }
        public void Blorb() { _bar.Blorb(); }
    }
