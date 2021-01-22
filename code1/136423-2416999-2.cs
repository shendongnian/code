    public class BlogPostViewModel
    {
         public string Title { get; set; }
         public string Body { get; set; }
         public IEnumerable<BlogComment> Comments { get; set; }
    }
