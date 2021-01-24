    public class DisplayCard : ICard<MyCard>, IGetCard<YourCard>
    {
        public MyCard WithBoard(string boardName)
        {
            // ...do stuff...
            return ...;
        }
        public YourCard WithBoard(string boardName)
        {
            // ...do stuff...
            return ...;
        }
    }
