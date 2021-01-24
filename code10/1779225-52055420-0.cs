    public class GetCard : IGetCard<MyCard>
    {
      public MyCard WithBoard(string boardName)
      {
        // ...do stuff...
        return this;
      }
    }
