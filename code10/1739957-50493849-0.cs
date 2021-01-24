    public abstract class MyBasePageModel : PageModel
    {
       protected readonly ApplicationDbContext _dbContext;
       public MyBaseModel(ApplicationDbContext dbContext)
       {
          _dbContext = dbContext;
       }
    }
    
    
    public class IndexModel : MyBasePageModel 
    {
      //
    }
