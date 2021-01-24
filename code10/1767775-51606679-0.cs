    internal class A {
        public virtual void DoSomething() { }
    }
    internal class B : A {
        public override void DoSomething() { base.DoSomething(); }
    }
