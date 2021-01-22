        public class Travel
        {
          public int MinAirportArrival { get; set; }
          public int MinFlightTime { get; set; }
          public int AdditionalTravelTime { get; set; }
          public int TotalTravelTime
          {
            get
            {
              return MinAirportArrival + MinFlightTime + AdditionalTravelTime;
            }
          }
        }
    This takes advantage of the effect that the TotalTravelTime can be reconstructed from the three other values which can be indivually set without dependencies.
