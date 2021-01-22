    class A {
        protected virtual void basicM() {}
        public virtual void M() { basicM(); }
    }
    class C {
        public override void M() { basicM(); }
    }
