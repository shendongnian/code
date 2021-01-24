    public class Group {
        public int Id { get; set; }
        public int Name { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<Section> Sections { get; set; }
    }
    
    public class Section {
        public int Id { get; set; }
        public int Name { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
