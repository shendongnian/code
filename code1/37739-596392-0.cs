    public class MyCollection<T> : ICollection<T>
    where T : ResultInfo
    {
    
         ... the required methods ... just use "T" instead of "ResultInfo" ...
    
        public void Add(T item) {}
    }
