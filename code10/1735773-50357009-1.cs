    public class Cars
    {
        public Cars( string description, string model, string title,  string id)
        {
            Id = id;
            Description = description;
            Model = model;
            Title = title;
        }
        public string Id { get; set; }
        public string Title { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
    }
