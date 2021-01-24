    using System.ComponentModel.DataAnnotations;
    suing System.ComponentModel.DataAnnotations.Schema
    public class Tag
    {
        public int ID { get; set; }
        public string Name { get; set; }
        [Required]
        [ForeignKey("BlogId")]
        public virtual Blog Blog { get; set; }
        
        public virtual Guid BlogId { get; set; };
    }
