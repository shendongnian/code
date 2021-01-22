    [MetadataType(typeof(CommentMetaData))]
    public partial class Comment {
    }
    public class CommentMetaData {
        [StringLength(50),Required]
        public object Name { get; set; }
        [StringLength(15)]
        public object Color { get; set; }
        [Range(0, 9999)]
        public object Weight { get; set; }
    }
