        public class Travel
        {
          public int MinAirportArrival { get; private set; }
          public int MinFlightTime { get; private set; }
          public int TravelTime { get; private set; }
          public void UpdateTimes(
            int minAirportArrival, int minFlightTime, int travelTime)
          {
            // validate travelTime > minAirportArrival + minFlightTime 
            MinAirportArrival = minAirportArrival;
            MinFlightTime = minFlightTime;
            TravelTime = travelTime;
          }
        }
