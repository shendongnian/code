    protected void Page_Load(object sender, EventArgs e)
    {
        BLL.PostCollection oPost = new BLL.PostCollection();
        rptPosts.DataSource = Post.OpenRecent();
        rptPosts.DataBind();
    }
    public class Post
    {
        public int PostId { get; set; }
        public string PostTitle { get; set; }
        public string PostContent { get; set; }
        public string PostCreatedDate { get; set; }
    
        public void OpenRecentInitFromRow(DataRow row)
        {
            this.PostId = (int) row["id"];
            this.PostTitle = (string) row["title"];
            this.PostContent = (string) row["content"];
            this.PostCreatedDate = (DateTime) row["createddate"];
        }
    
        public static List<Post> OpenRecent()
        {
            DataSet ds = DbProvider.Instance().Post_ListRecent();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Post oPost = new Post();
                oPost.OpenRecentInitFromRow(row);
                Add(oPost); //Not sure what this is doing
            }
            //need to return a List<Post>
        }
    }
