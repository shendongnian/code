        public class Travel
        {
          public int MinAirportArrival { get; set; }
          public int MinFlightTime { get; set; }
          public int TravelTime { get; set; }
          public void Save()
          {
            // validate TravelTime > MinAirportArrival + MinFlightTime 
          }
        }
