        static void Main(string[] args)
        {
            var listOfListOfPlayers = new List<List<Player>>();
            //Flatten the list, so not having to deal with lists of lists
            var allPlayers = listOfListOfPlayers.SelectMany(l => l).ToList();
            //Count the players that can not take part of a flight
            var playersNotFittingInFlight = allPlayers.Count % 4;
            //The number of players that will be spread in flights
            var maxPlayersInFlights = allPlayers.Count - playersNotFittingInFlight;
            //The number of flights you will end up having
            var maxFlights = maxPlayersInFlights / 4;
            var flights = new List<Flight>(maxFlights);
            //Create the flights with the players
            for (var i=0;i<maxPlayersInFlights; i=i+4)
            {
                var flight = new Flight();
                //Take 4 players everytime.
                var players = allPlayers.Skip(i * 4).Take(4);
                flight.Players.AddRange(players);
                flights.Add(flight);
            }
        }
        public class Flight
        {
            public List<Player> Players { get; set; } = new List<Player>();
        }
        public class Player
        {
        }
    }
