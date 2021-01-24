    public class WrapperOne
    {
        protected IShimOne It { get; }
        protected WrapperOne(IShimOne it) { It = it; }
        public WrapperOne() { It = ShimFactory.CreateOne(); }
        public void MethodOne() { It.MethodOne(); }
    }
    public class WrapperTwo: WrapperOne
    {
        protected new IShimTwo It => (IShimTwo)base.It;
        protected WrapperTwo(IShimTwo it): base(it) {}
        public WrapperTwo(): base(ShimFactory.CreateTwo()) {}
        public void MethodTwo() { It.MethodTwo(); }
    
