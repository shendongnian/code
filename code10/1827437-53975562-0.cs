    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApp1
    {
        public class Station
        {
            public string stationName;
            public string stationId;
        }
    
        public class Line
        {
            public List<Station> stations = new List<Station>();
        }
    
        class Program
        {
            static void Main(string[] argv)
            {
                using (StreamReader reader = new StreamReader(argv[0]))
                {
                    string temp;
                    Line line = new Line();
                    int i = 0;
    
                    while ((temp = reader.ReadLine()) != null)
                    {
                        line.stations.Add(new Station
                        {
                            stationName = temp,
                            stationId = (++i).ToString()
                        });
                    }
    
                    //For printing
                    foreach (var station in line.stations)
                    {
                        Console.WriteLine(station.stationName);
                        Console.WriteLine(station.stationId);
                    }
    
                    Console.ReadLine();
                }
            }
        }
    }
