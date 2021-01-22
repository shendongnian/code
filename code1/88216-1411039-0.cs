    public class Travel
    {
       /// <summary>
       /// Creates a new instance of <see cref="Travel"/>.
       /// </summary>
       public Travel()
       {
          this.TravelName = Resources.DefaultTravelName;
          this.TravelDescription = Resources.DefaultTravelDescription;
       }
    
       public string TravelName { get; set; }
    
       public string TravelDescription { get; set; }
    }
