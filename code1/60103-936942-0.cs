    public static class MyBaseClassExtensions
    {
        public static IQueryable<T> ShowThisMethod<T>(this MyBaseClass<T> mbc)
            where T: class, IMyInterface
        {
            ...
        }
    }
