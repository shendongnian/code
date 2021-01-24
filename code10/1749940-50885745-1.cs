    public class MyHub
    {
          private PlayerContext dbContext;
     
          public MyHub(PlayerContext dbContext)
          {
               this.dbContext = dbContext;
          }
          public void YourMethod()
          {
                 //now you can call the dbContext by Dotnotaition
          }
     }
