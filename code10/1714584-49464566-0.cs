        //Seprate class for all the collection declarations
        public class GPSdata
        {
            public static List<GPSdata> data = new List<GPSdata>();
            public DateTime List time { get;set;}     //time (in seconds, advances by 0.2)
            public decimal lat { get;set;}      //Latitude
            public string NS { get;set;}       //North/South
            public decimal lon { get;set;}      //Longtitude
            public string EW { get;set;}       //East/West
            public int knots { get;set;}    //Speed in Knots
            public DateTime date { get;set;}     //Date [ddmmyy]
            public string sats { get;set;}     //**No clue**
            public decimal HDOP { get;set;}     //Satelite Horizontal error
            public decimal alt { get;set;}      //Elevation (above msl)
            public int rawSV { get;set;}    //Space Vehicle
        }
