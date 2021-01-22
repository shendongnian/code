    public interface IHasChildren<T>
    {
        List<T> Children { get; set; }
    }
    public interface IHasParent<T>
    {
        T Parent { get; set; }
    }
    public class A<TParent, TChildren> : IHasChildren<TChildren>, IHasParent<TParent>
        where TParent : IHasChildren<A<TParent, TChildren>>
        where TChildren : IHasParent<A<TParent, TChildren>>
    {
        public List<TChildren> Children { get; set; }
        public TParent Parent { get; set; }
    }
