    public class MyBaseClass<T> where T: class
    {
        public IQueryable<R> ShowThisMethod() where R: T, IMyInterface
        {
             Debug.Assert(typeof(R) == typeof(T));
             // stuff.
        }
    }
