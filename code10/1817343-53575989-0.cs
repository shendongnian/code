    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<Train> trains = new List<Train>();
                string source = "abc";
                string destination = "xyz";
                var results = trains.Where(x => x.Routes.Any(y => y.StationId == source) && x.Routes.Any(y => y.StationId == destination))
                    .Select(x => new {
                        source = x.Routes.Where(y => y.StationId == source).FirstOrDefault(),
                        destination = x.Routes.Where(y => y.StationId == destination).FirstOrDefault()
                    })
                    .Where(x => x.destination.StopNumber > x.source.StopNumber)
                    .ToList();
            }
        }
        public class Train
        {
            public string TrainName { get; set; }
            public List<Route> Routes { get; set; }
        }
        public class Route
        {
            public string TrainId { get; set; }
            public string StationId { get; set; }
            public int StopNumber { get; set; }
        }
    }
