    public partial class Country
    {
         [Key]
         public int ID { get; private set; }
         public ICollection<City> Cities { get; set; }
    } 
    public partial class City
    {
         [Key]
         public int City_ID { get; private set; } 
         [ForeignKey("Country")]
         public int Country_ID { get; private set; } 
         public Country Country { get; set; }
    }
