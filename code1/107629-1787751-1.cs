    public class Travel
    {
      public int MinAirportArrival { get; set; }
      public int MinFlightTime { get; set; }
      public int AdditionalTravelTime { get; set; }
      public int TotalTravelTime
      {
          get { return MinAirportArrival + MinFlightTime + AdditionalTravelTime; }
      }
    }
