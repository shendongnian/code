    public class SomeHelper<T,U>
    {
    
        public static readonly Func<
            (IEnumerable<T>, IEnumerable<U>),
            (IEnumerable<T>, IEnumerable<U>),
            (IEnumerable<T>, IEnumerable<U>)> 
                JoinListTuples = (a, b) => 
                   (a.Item1.Concat(b.Item1),b.Item2.Concat(b.Item2));
    
    }
