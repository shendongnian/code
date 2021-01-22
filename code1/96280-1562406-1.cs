    class Project {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Thumb { get; set; }
        public List<Screenshot> Screenshots { get; private set; }
        public Project( int id, string name, string description, string thumb,
                IEnumerable<Screenshot> screenshots) {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.Thumb = thumb;
            this.Screenshots = screenshots == null ? new List<Screenshot>()
                     : new List<Screenshot>(screenshots);
        }
    }
    class Screenshot {
        public string Path { get; set; }
        public string Description { get; set; }
        public Screenshot(string path,string description) {
            this.Path = path;
            this.Description = description;
        }
    }
