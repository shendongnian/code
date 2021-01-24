            List<geo_tag> abc = new List<geo_tag> {};
            abc.Add(new geo_tag(11, 112, "SSS"));
      public class geo_tag
    {
        public int latitude { get; set; }
        public int longitude { get; set; }
        public string unit { get; set; }
        public geo_tag()
        {
        }
        public geo_tag(int latitude, int longitude, string unit)
        {
            this.latitude = latitude;
            this.longitude = longitude;
            this.unit = unit;
        }
    }
