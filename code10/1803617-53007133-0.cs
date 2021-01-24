    public class Post
    {
        public Guid Id { get; set; }
        public virtual List<File> Files { get; set; }
    }
    public class File
    {
        public virtual Post Post { get; set; }
        public Guid PostId { get set; }
        public Guid Id { get; set; }
        public string PhysicalPath { get; set}
    }
