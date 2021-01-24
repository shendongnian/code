    public class BlogEntity : TableEntity
    {
        public BlogEntity() { }
        public BlogEntity(int ID, string author, string title, string description)
        {
            this.UniqueID = ID;
            this.Author = author;
            this.Title = title;
            this.Description = description;
            this.PartitionKey = "blog";
            this.RowKey = ID.ToString();
        }
        public int UniqueID { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
