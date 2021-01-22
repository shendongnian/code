     public partial class MyNorthwindDataContext : NorthwindDataContext
     {
    
      public MyNorthwindDataContext()
      {
      
      }
    
      public override void SubmitChanges(System.Data.Linq.ConflictMode failureMode)
      {
       //catch error logic here...
       
       base.SubmitChanges(failureMode);
      }
     }
