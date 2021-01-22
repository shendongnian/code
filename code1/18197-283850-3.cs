    public class Bose : Person
    {
        public virtual T Create<T>()
            where T : IFieldNormalItem
        {
            return default(T);
        } 
    }
