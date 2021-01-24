    public class Player
    {
        // All the rest you already coded
        [Required]
        public int ImageID
        [ForeignKey("ImageID")]
        public virtual DKImage DKImage {get;set;}
    }
