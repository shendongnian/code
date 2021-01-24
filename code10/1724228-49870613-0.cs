    public class User
    {
        public int Id
        {
            get; set;
        }
        public string Name
        {
            get; set;
        }
        public ICollection<BlogPost> Blogs
        {
            get; set;
        }
        public ICollection<User> Followers
        {
            get; set;
        }
    }
    public class BlogPost
    {
        public int Id
        {
            get; set;
        }
        public string Title
        {
            get; set;
        }
        public string Content
        {
            get; set;
        }
        public User CreatedBy
        {
            get; set;
        }
    }
