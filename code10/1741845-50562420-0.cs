    public class CustomUserFields
    {
    }
    
    public class CustomApplicationFields
    {
    }
    
    public class CommentPrompts
    {
        public bool AskForCommentOnViewPassword { get; set; }
        public bool AskForCommentOnViewOffline { get; set; }
        public bool AskForCommentOnModifyEntries { get; set; }
        public bool AskForCommentOnMoveEntries { get; set; }
        public bool AskForCommentOnMoveFolders { get; set; }
        public bool AskForCommentOnModifyFolders { get; set; }
    }
    
    public class RootObject
    {
        public CustomUserFields CustomUserFields { get; set; }
        public CustomApplicationFields CustomApplicationFields { get; set; }
        public List<object> Attachments { get; set; }
        public List<object> Tags { get; set; }
        public bool HasModifyEntriesAccess { get; set; }
        public bool HasViewEntryContentsAccess { get; set; }
        public CommentPrompts CommentPrompts { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public object Password { get; set; }
        public string Url { get; set; }
        public string Notes { get; set; }
        public string GroupId { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public object Expires { get; set; }
        public object UsageComment { get; set; }
    }
