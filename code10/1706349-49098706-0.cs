    class Report
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [NotMapped]
        public <sometype> <SomeProperty> { get; set; }
    }
