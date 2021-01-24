    public interface IGetCard<T>
    {
        // be aware that I omitted the <T> from the signature, as T is 
        // already defined on the class-level
        T WithBoard(string boardName); 
    }
    public class GetCard : IGetCard<MyCard>
    {
        public GetCard WithBoard(string boardName)
        {
            // ...do stuff...
            return this;
        }
    }
