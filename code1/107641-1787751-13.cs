        public class Travel
        {
          public static Travel CreateTravel(
            int minAirportArrival, int minFlightTime, int travelTime)
          {
            // validate travelTime > minAirportArrival + minFlightTime 
          }
          private Travel(int minAirportArrival, int minFlightTime, int travelTime);
          public int MinAirportArrival { get; }
          public int MinFlightTime { get; }
          public int TravelTime { get; }
        }
