    public interface IFoo {}
    public interface IBar {}
    
    public class ParentFoo<T,T1> { }
    public class DerivedFoo<T, T1> : ParentFoo<T, T1>, IFoo where T1 : IBar { }
