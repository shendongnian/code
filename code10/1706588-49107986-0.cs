    class BaseProp { }
    class DerivedPropA: BaseProp { }
    class DerivedPropB : BaseProp { }
    abstract class X<T>
        where T: BaseProp
    {
        public T Value { get; set; }
        public abstract void With(T value);
    }
    class A : X<DerivedPropA>
    {
        public override void With(DerivedPropA value)
        {
            this.Value = value;
        }
    }
    class B : X<DerivedPropB>
    {
        public override void With(DerivedPropB value)
        {
            this.Value = value;
        }
    }
