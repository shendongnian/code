    using System;
    using System.Collections.Generic;
    using System.Device.Location;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace TestConsoleApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                var path = new List<Location>
                {
                    new Location(1,1),
                    new Location(2, 2),
                    new Location(3, 3),
                };
                var point = new Location(1.9, 1.5);
                bool isOnEdge = isLocationOnEdge(path, point);
                Console.ReadKey();
            }
            static bool isLocationOnEdge(List<Location> path, Location point, int tolerance = 2)
            {
                var C = new GeoCoordinate(point.Lat, point.Lng);
                for (int i = 0; i < path.Count - 1; i++)
                {
                    var A = new GeoCoordinate(path[i].Lat, path[i].Lng);
                    var B = new GeoCoordinate(path[i + 1].Lat, path[i + 1].Lng);
                    if (Math.Round(A.GetDistanceTo(C) + B.GetDistanceTo(C), tolerance) == Math.Round(A.GetDistanceTo(B), tolerance))
                    {
                        return true;
                    }
                }
                return false;
            }
        }
        class Location
        {
            public Location(double Lat, double Lng)
            {
                this.Lat = Lat;
                this.Lng = Lng;
            }
            public double Lat { get; set; }
            public double Lng { get; set; }
        }
    }
