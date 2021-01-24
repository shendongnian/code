    {
    public class Airport
    {
        [Key]
        public int Id { get; set; }
        public string Locatoin { get; set; }
        
        [InverseProperty(nameof(Flight.ToAirportId))]
        public ICollection<Flight> ComingFlightsId { get; set; }
        [InverseProperty(nameof(Flight.FromAirportId))]
        public ICollection<Flight> GoingFlightsId { get; set; }
    }}
