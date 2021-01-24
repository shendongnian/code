    public interface IGetCard<out TCard>
    {
        TCard WithBoard(string boardName);
    }
    public class DisplayCard : IDisplayCard, IGetCard<IDisplayCard>
    {
        public IDisplayCard WithBoard(string boardName)
        {
           // ...do stuff...
           return this;
        }
    }
