    public class Post
    {
          public Post()
          {
              Images = new List<Image>();
          }
            
          // Other attributes here...
          
          public ICollection<Image> Images { get; set; }
    }
