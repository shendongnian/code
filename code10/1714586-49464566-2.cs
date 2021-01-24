    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.csv";
            static void Main(string[] args)
            {
                new GPSdata(FILENAME);
            }
        }
        //Seprate class for all the collection declarations
        public class GPSdata
        {
            public static List<GPSdata> data = new List<GPSdata>();
            public TimeSpan time { get; set; }     //time (in seconds, advances by 0.2)
            public decimal lat { get; set; }      //Latitude
            public string NS { get; set; }       //North/South
            public decimal lon { get; set; }      //Longtitude
            public string EW { get; set; }       //East/West
            public decimal knots { get; set; }    //Speed in Knots
            public DateTime date { get; set; }     //Date [ddmmyy]
            public int sats { get; set; }     //**No clue**
            public decimal HDOP { get; set; }     //Satelite Horizontal error
            public decimal alt { get; set; }      //Elevation (above msl)
            public int rawSV { get; set; }    //Space Vehicle
            public GPSdata() { }
            public GPSdata(string filepath)
            {
                using (StreamReader reader = new StreamReader(filepath))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        string[] values = line.Split(',');
                        GPSdata gpsdata = new GPSdata();
                        GPSdata.data.Add(gpsdata);
                        gpsdata.time = new TimeSpan((long)(decimal.Parse(values[0]) * (decimal)1.0E07));
                        gpsdata.lat = decimal.Parse(values[1]);
                        gpsdata.NS = values[2];
                        gpsdata.lon = decimal.Parse(values[3]);
                        gpsdata.EW = values[4];
                        gpsdata.knots = decimal.Parse(values[5]);
                        int dateLen = values[6].Length;
                        gpsdata.date = new DateTime(int.Parse(values[6].Substring(dateLen - 2)),int.Parse(values[6].Substring(0, dateLen - 4)) ,int.Parse(values[6].Substring(dateLen - 4,2)));
                        gpsdata.sats = int.Parse(values[7]);
                        gpsdata.HDOP = decimal.Parse(values[8]);
                        gpsdata.rawSV = int.Parse(values[9]);
                        gpsdata.alt = decimal.Parse(values[10]);
                    }
                }
            }
        }
    }
