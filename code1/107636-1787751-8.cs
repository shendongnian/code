        public class Travel
        {
          public static Travel CreateTravel(
              int minAirportArrival, int minFlightTime, int travelTime)
          {
            // validate TravelTime > MinAirportArrival + MinFlightTime 
          }
          private Travel(int minAirportArrival, int minFlightTime, int travelTime);
          public int MinAirportArrival { get; }
          public int MinFlightTime { get; }
          public int TravelTime { get; }
        }
