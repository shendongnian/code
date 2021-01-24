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
            public int latDegrees { get; set; }      //Latitude
            public int latMinutes { get; set; }      //Latitude
            public int latSeconds { get; set; }      //Latitude
            public string NS { get; set; }       //North/South
            public int lonDegrees { get; set; }      //Longtitude
            public int lonMinutes { get; set; }      //Longtitude
            public int lonSeconds { get; set; }      //Longtitude
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
                int lineNumber = 0;
                StreamReader reader = new StreamReader(filepath);
               
                string line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    if (++lineNumber > 8)
                    {
                        try
                        {
                            string[] values = line.Split(',');
                            GPSdata gpsdata = new GPSdata();
                            GPSdata.data.Add(gpsdata);
                            gpsdata.time = new TimeSpan((long)(decimal.Parse(values[0]) * (decimal)1.0E07));
                            int latDecimalPoint = values[1].IndexOf(".");
                            gpsdata.latSeconds = int.Parse(values[1].Substring(latDecimalPoint + 1));
                            gpsdata.latMinutes = int.Parse(values[1].Substring(latDecimalPoint - 2, 2));
                            gpsdata.latDegrees = int.Parse(values[1].Substring(0, latDecimalPoint - 2));
                            gpsdata.NS = values[2];
                            int lonDecimalPoint = values[3].IndexOf(".");
                            gpsdata.lonSeconds = int.Parse(values[3].Substring(lonDecimalPoint + 1));
                            gpsdata.lonMinutes = int.Parse(values[3].Substring(lonDecimalPoint - 2, 2));
                            gpsdata.lonDegrees = int.Parse(values[3].Substring(0, lonDecimalPoint - 2));
                            gpsdata.EW = values[4];
                            gpsdata.knots = decimal.Parse(values[5]);
                            int dateLen = values[6].Length;
                            gpsdata.date = new DateTime(int.Parse(values[6].Substring(dateLen - 2)), int.Parse(values[6].Substring(0, dateLen - 4)), int.Parse(values[6].Substring(dateLen - 4, 2)));
                            gpsdata.sats = int.Parse(values[7]);
                            gpsdata.HDOP = decimal.Parse(values[8]);
                            gpsdata.rawSV = int.Parse(values[9]);
                            gpsdata.alt = decimal.Parse(values[10]);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error Line Number : '{0}',  Text : '{1}'", lineNumber,line);
                        }
                    }
                }
                Console.ReadLine();
            }
        }
    }
