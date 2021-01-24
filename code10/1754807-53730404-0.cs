    public class Post
    {
        private Post() { }
        public Post(Blog blog)
        {
            Blog = blog ?? throw new ArgumentNullException(nameof(blog));
        }
        public int PostId { get; private set; }
        public int BlogId {get; private set; } # Foreign Key Property
        public Blog Blog { get; private set; }
    }
    public class Blog
    {
        public int BlogId { get; private set; }
    }
