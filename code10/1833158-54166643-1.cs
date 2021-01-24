    public class Favourite
    {
        public long FavouriteId { get; set; }
        public long AdId { get; set; }
        public long UserId { get; set; }
      
        public virtual Ad Ad { get; set; }
    }
