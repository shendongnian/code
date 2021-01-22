    public class Person<T> where T : IFieldSimpleItem
    {
        public virtual T Create()
        {
            return default(T);
        }
    }
    
    public class Bose<T> : Person<T> where T : IFieldNormalItem
    {
        public override T Create()
        {
            return default(T);
        } 
    }
