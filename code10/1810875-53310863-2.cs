    public class Story
    {
        public List<Comment> Comments { get; set; }
        public int InsightFulVoteCount { get; set; }
        public int UsefulVoteCount { get; set; }
        public int ViewCount { get; set; }
        public int PopularityScore
        {
            get
            {
                return
                    (Comments?.Count ?? 0) * 4 +
                    (Comments?.SelectMany(comment => comment.Replies).Count() ?? 0) * 4 +
                    InsightFulVoteCount * 3 +
                    UsefulVoteCount * 2 +
                    ViewCount;
            }
        }
    }
    public class Comment
    {
        public List<string> Replies { get; set; }
    }
