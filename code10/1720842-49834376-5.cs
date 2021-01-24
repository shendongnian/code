    public class Image
    {
        //Fields and Properties//
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }<-be virtual
        public virtual string ApplicationUserId { get; set; }<--must be virtual
        public Image()
        {
        }
        public Image(string path) => Path = path;
    }
