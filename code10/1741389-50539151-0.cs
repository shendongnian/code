    public partial class User
    {
       public User()
       {
          Advertisers = new HashSet<Advertiser>();
       }    
       ...
       public virtual ICollection<Advertiser> Advertisers { get; set; }
    }
