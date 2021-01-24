    //note: using interface so implementation can be changed later
    public interface ICache
    {
         //store by key, use resolver if not present.
         T GetOrAdd(string key, Func<T> resolver);
         //invalidate all
         void Invalidate();
         //invalidate by key
         void Invalidate(string key);
    }
