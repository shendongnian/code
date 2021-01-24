    public class MyHub
    {
          private PlayerContext dbContext;
     
          public MyHub(PlayerContext dbContext)
          {
               this.dbContext = dbContext;
          }
          public void YourMethod()
          {
               //call the dbContext here by Dot Notaition
          }
    }
