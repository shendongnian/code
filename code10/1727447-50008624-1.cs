    public partial class Restaurant
    {
      public int Id{get;set;}
      //Rest all other fields.
      
      //Foreign key relationship/ Navigation property
      public List<Reviews> Reviews {get;set;}
    } 
