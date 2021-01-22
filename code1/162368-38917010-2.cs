    using System;
    using System.Xml.Serialization;
    [Serializable]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class GeocodeResponse
    {
        public GeocodeResponse()
        {
        }
        [XmlElement("result")]
        public results[] results { get; set; }
        public string status { get; set; }
    }
    [XmlType(AnonymousType = true)]
    public class results
    {
        public results()
        {
        }
        [XmlElement("address_component")]
        public address_component[] address_components { get; set; }
        public string formatted_address { get; set; }
        public geometry geometry { get; set; }
        [XmlElement("type")]
        public string[] types { get; set; }
        public string[] postcode_localities { get; set; }
        public bool partial_match { get; set; }
        public string place_id { get; set; }
    }
    [XmlType(AnonymousType = true)]
    public class address_component
    {
        public address_component()
        {
        }
        public string long_name { get; set; }
        public string short_name { get; set; }
        [XmlElement("type")]
        public string[] types { get; set; }
    }
    [XmlType(AnonymousType = true)]
    public class geometry
    {
        public geometry()
        {
        }
        public bounds bounds { get; set; }
        public location location { get; set; }
        public string location_type { get; set; }
        public viewport viewport { get; set; }
    }
    [XmlType(AnonymousType = true)]
    public class location
    {
        public location()
        {
        }
        public double lat { get; set; }
        public double lng { get; set; }
    }
    [XmlType(AnonymousType = true)]
    public class viewport
    {
        public viewport()
        {
        }
        public northeast northeast { get; set; }
        public southwest southwest { get; set; }
    }
    [XmlType(AnonymousType = true)]
    public class bounds
    {
        public bounds()
        {
        }
        public northeast northeast { get; set; }
    }
    [XmlType(AnonymousType = true)]
    public class northeast
    {
        public northeast()
        {
        }
        public double lat { get; set; }
        public double lng { get; set; }
    }
    [XmlType(AnonymousType = true)]
    public class southwest
    {
        public southwest()
        {
        }
        public double lat { get; set; }
        public double lng { get; set; }
    }
