      [Table("MySchema.Content")]
    public class Content
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public ICollection<ContentState> ContentStates { get; set; }
    }
    [Table("dbo.State")]
    public class State
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public ICollection<ContentState> ContentStates { get; set; }
    }
    public class ContentState
    {
        public int ContentId { get; set; }
        public int StateId { get; set; }
        public Content Content { get; set; }
        public State State { get; set; }
    }
