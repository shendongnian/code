    public class Airport
    {
      public int Id { get; set; }
      [InverseProperty("FromAirport")]
      public ICollection<Flight> ComingFlights { get; set; }
      [InverseProperty("ToAirport")]
      public ICollection<Flight> GoingFlights { get; set; }
    }
    public class Flight
    {
       public int Id { get; set; }
       public int FromAirportId { get; set; }
       public int ToAirportId { get; set; }
       [ForeignKey(nameof(FromAirportId))]
       [InverseProperty("ComingFlights")]
       public Airport FromAirport { get; set; }
    
       [ForeignKey(nameof(ToAirportId))]
       [InverseProperty("GoingFlights")]
       public Airport ToAirport { get; set; }    
     }
