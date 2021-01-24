    public class Favourite
    {
        [Key]
        public Guid FavouriteId { get; set; }
        [ForeignKey("Business")]
        public Guid BusinessId { get; set; }
        [ForeignKey("Product")]
        public Guid ProductId { get; set; }
        public virtual Retailer Business { get; set; }
        public virtual Product Product { get; set; }
    }
