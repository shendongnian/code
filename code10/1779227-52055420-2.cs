    public class GetCard : IGetCard
    {
      public MyCard WithBoard<MyCard>(string boardName)
      {
        // ...do stuff...
        return this;
      }
    }
