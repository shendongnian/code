    public class TitleAuthor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; internal set;}
        public virtual Title Title { get; internal set;}
        public virtual Author Author { get; internal set;}
        // add other properties as needed..
    }
