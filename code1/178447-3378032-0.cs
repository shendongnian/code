    class A {
        public virtual void M() { m_protected(); }
        protected void m_protected() { /* code goes here */ }
    }
    class B {
        public override void M() { /* code here, possibly invoking base.M() */ }
    }
    class C {
        public override void M() { m_protected(); }
    }
