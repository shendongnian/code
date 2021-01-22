        public class TravelBuilder
        {
          public int MinAirportArrival { get; set; }
          public int MinFlightTime { get; set; }
          public int TravelTime { get; set; }
          public Travel BuildTravel()
          {
            // validate TravelTime > MinAirportArrival + MinFlightTime 
            return new Travel(MinAirportArrival, MinFlightTime, TravelTime);
          }
        }
