    [Serializable]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = true)]
    public class GeocodeResponse
    {
        public GeocodeResponse()
        {
          // can be empty or you can initiate the properties here
        }
    
        [XmlElement("location ")]
        [Display(Name = "location ")]
        // add json attributes as well
        public location  location { get; set; }
    
        public string status { get; set; }
      }
