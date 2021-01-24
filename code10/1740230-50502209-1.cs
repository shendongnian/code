    public class BlogPost
    {
        public int BlogPostId { get; set; }
        public string BlogPostTitle { get; set; }
        public string BlogPostDescription { get; set; }
        public int Upvotes { get; set; }
        public int Downvotes { get; set; }
        public int TotalVotes {get => GetTotalVotes(); }   
        // A method just in case if you need to do some extra calculations or validations
        private int GetTotalVotes()
        {
            //I am assuming the TotalVotes should not go below 0;
            //You can change it as you like
            int value = UpVotes - DownVotes;
        
            return value<0? 0 : value;
        }
    }
