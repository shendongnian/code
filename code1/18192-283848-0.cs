    public interface IFieldNormalItem : IFieldSimpleItem
    { }
    
    public class Person<T> where T : IFieldSimpleItem
    {
        public virtual T Create()
        {
            return default(T);
        }
    }
