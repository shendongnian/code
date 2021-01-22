    public class Post
    {
        public int PostId { get; set; }
        public string PostTitle { get; set; }
        public string PostContent { get; set; }
        public string PostCreatedDate { get; set; }
    }
    
    public class PostCollection : List<Post>
    {
        public void OpenRecent()
        {
            DataSet ds = DbProvider.Instance().Post_ListRecent();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Add(LoadPostFromRow(row));
            }
        }
    
        private Post LoadPostFromRow(DataRow row)
        {
            Post post = new Post();
            post.PostId = (int) row["id"];
            post.PostTitle = (string) row["title"];
            post.PostContent = (string) row["content"];
            post.PostCreatedDate = (DateTime) row["createddate"];
            return post;
        }
    }
