    public partial class WebsiteUser
    {
    // ...
        [InverseProperty("PostedBy")] // Solved the problem
        public virtual ICollection<LessonComment> LessonComments { get; set; }
    }
