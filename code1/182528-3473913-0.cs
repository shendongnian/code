    [MetadataType(typeof(CommentMetadata))]
    public partial class Comment {
    }
    public class CommentMetadata {
        [IsEmailAddress]
        public string email {get;set;}
    }
