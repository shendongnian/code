    public class DisplayCard : ICard<MyCard>, IGetCard<YourCard>
    {
        public MyCard WithBoard(string boardName)
        {
            // ...do stuff...
            return this;
        }
        public YourCard WithBoard(string boardName)
        {
            // ...do stuff...
            return this;
        }
    }
