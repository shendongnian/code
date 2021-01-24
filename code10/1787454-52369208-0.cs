    public class BaseDemo<A, B>
        where A : IEquatable<A>
        where B : IList<A>, new()
    {
    }
    
    public class Demo<B> : BaseDemo<B, List<B>>
        where B : IEquatable<B> 
    {
    }
