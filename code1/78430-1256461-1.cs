    public class BlogPostMap : ClassMap<BlogPost>
    {
        public BlogPostMap()
        {
            Id(b => b.Id);
            Map(b => b.Title);
            Map(b => b.Body);
            HasMany(b => b.Comments).KeyColumnNames.Add("BlogPostId");
        }
    }
    public class CommentMap : ClassMap<Comment>
    {
        public CommentMap()
        {
            Id(c => c.Id);
            Map(c => c.BlogPostId);
            Map(c => c.Text);
            Map(c => c.DatePosted);
        }
    }
    public class BlogPost
    {
        public virtual int Id { get; set; }
        public virtual string Title { get; set; }
        public virtual string Body { get; set; }
        public virtual IList<Comment> Comments { get; set; }
    }
    public class Comment
    {
        public virtual int Id { get; set; }
        public virtual int BlogPostId { get; set; }
        public virtual string Text { get; set; }
        public virtual DateTime DatePosted { get; set; }
    }
