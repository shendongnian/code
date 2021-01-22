    public interface IFoo { }
    
    public class ConcreteFoo : IFoo { }
    
    public abstract class Bar
    {
        private IFoo m_Foo;
    
        public IFoo Foo
        {
            get { return m_Foo; }
        }
    
        protected void SetFoo(IFoo foo)
        {
            m_Foo = foo;
        }
    }
    
    public class ConcreteBar : Bar
    {
        public ConcreteA(ConcreteFoo foo)
        {
            SetFoo(foo);
        }
    
        public new ConcreteFoo Foo
        {
            get { return (ConcreteFoo)base.Foo; }
        } 
    }
