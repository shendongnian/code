    public struct LocationDetail 
    {
        private string site;
        public string Site
        {
            get { return site; }
            set { site = value; }
        }
    }
    static void Main(string[] args)
    {
        LocationResponse response = new LocationResponse();
        response.LocationDetails = new LocationDetail[4];
        response.LocationDetails[0].Site = "ABCDE";
        Console.Write(response.LocationDetails[0].Site);
    }
