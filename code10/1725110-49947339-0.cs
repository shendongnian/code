    public interface IAbstractParams
    {
       IBarAwesome awesome { get; } 
       IBarCool cool { get; }
       ... 
    }
    public class FooComplex : AbstractFoo 
    {
        public FooComplex(IAbstractParams params) : base(params) { }
        ...a lot of overriding abstracts
    }
    public class FooSimple : AbstractFoo
    {
        public FooSimple(IAbstractParams params) : base(params) { }
        ...little bit of overriding abstracts
    }
    
    public class AbstractFoo
    {
        protected readonly IBarAwesome _awesome;
        protected readonly IBarCool _cool;
        public AbstractFoo(IAbstractParams params)
        {
         _awesome = params.awesome;
         _cool = params.cool;
        }
        ...heavy lifting
    }
