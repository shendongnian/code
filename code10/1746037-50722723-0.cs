    public class Blog
    {
        private ICollection<Post> _posts;
    
        public Blog()
        {
        }
    
        private Blog(ILazyLoader lazyLoader)
        {
            LazyLoader = lazyLoader;
        }
    
        private ILazyLoader LazyLoader { get; set; }
    
        public int Id { get; set; }
        public string Name { get; set; }
    
        public ICollection<Post> Posts
        {
            get => LazyLoader?.Load(this, ref _posts);
            set => _posts = value;
        }
    }
