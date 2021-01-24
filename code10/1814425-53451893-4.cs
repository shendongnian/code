    public partial class Blog
    {
        public int blogId { get; set; }
        public string blogTitle { get; set; }
        public int? authorId { get; set; }
        public virtual Author Author { get; set; }
    }
