    public interface IDispatchFilter {}
    public class WindowsXpFilter : IDispatchFilter { }
    public class ResolveMe
    {
        public IEnumerable<IDispatchFilter> Stuff { get; set; }
        public ResolveMe(IEnumerable<IDispatchFilter> stuff) { Stuff = stuff; }
    }
