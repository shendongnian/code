    public class Advertiser
    {
        public virtual int AdvertiserId { get; set; }
        public virtual string AdvertiserName { get; set; }
        public virtual bool IsPriorityEntity { get { return Priority != null; } }
        public PriorityEntity Priority { get; set; }
    }
