    public class Page
    {
      public string Name {get; set;}
      public int Template {get; set;}
      public DateTime Created {get; set;}
      
      public Page()
      {
        this.Created = DateTime.Now;
      }
    }
