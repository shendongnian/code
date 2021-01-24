    public class Favourite
    {
        [Key]
        public Guid FavouriteId { get; set; }
        public Guid BusinessId { get; set; }
        public Guid ProductId { get; set; }
        [ForeignKey("BusinessId")]
        public virtual Retailer Business { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
