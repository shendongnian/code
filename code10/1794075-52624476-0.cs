    public static class EnumerableExtensions
    {
        public static MyClass ToMyClass<TSource>(this Enumerable enumerable, Func<TSource,int> keySelector, Func<TSource,string> elementSelector)
        {
            return new Myclass(enumerable.ToDictionary(keySelector, elementSelector));
        }
    }
    
    ...
    MyClass myClass = myList.ToMyClass(l => l.Key, l => l.value);
