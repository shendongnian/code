    public partial class Author
    {  
        public Author()
        {
            Blogs = new HashSet<Blog>();
        }
        public int authorId { get; set; }
        public string name { get; set; }
        public virtual ICollection<Blog> Blogs { get; set; }
    }
