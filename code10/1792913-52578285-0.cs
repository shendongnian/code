    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Xml;
    using System.Xml.Serialization;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataSet ds = new DataSet("Availability");
                DataTable dtFlight = new DataTable("Flight");
                ds.Tables.Add(dtFlight);
                dtFlight.Columns.Add("Airline RCD",typeof(string));
                dtFlight.Columns.Add("Flight Number",typeof(string));
                dtFlight.Columns.Add("Booking Class",typeof(string));
                dtFlight.Columns.Add("Boarding Class",typeof(string));
                DataTable dtReturn = new DataTable("Return");
                ds.Tables.Add(dtReturn);
                dtReturn.Columns.Add("Airline RCD", typeof(string));
                dtReturn.Columns.Add("Flight Number", typeof(string));
                dtReturn.Columns.Add("Booking Class", typeof(string));
                dtReturn.Columns.Add("Boarding Class", typeof(string));
                string xml = "put your sting here";
                Availability availability = DeSerialize<Availability>.Index(xml);
                foreach (AvailabilityFlight flight in availability.AvailabilityOutbound.AvailabilityFlight)
                {
                    dtFlight.Rows.Add(new object[] { flight.Airline_rcd, flight.Flight_number, flight.Booking_class_rcd, flight.Boarding_class_rcd });
                }
                foreach (AvailabilityFlight flight in availability.AvailabilityReturn.AvailabilityFlight)
                {
                    dtReturn.Rows.Add(new object[] { flight.Airline_rcd, flight.Flight_number, flight.Booking_class_rcd, flight.Boarding_class_rcd });
                }
            }
     
        }
        public class DeSerialize<T>
        {
            public static T Index(string xmlResult)
            {
                var ser = new XmlSerializer(typeof(T));
                using (var sr = new StringReader(xmlResult))
                {
                     return (T)ser.Deserialize(sr);
                }
            }
        }
        [XmlRoot(ElementName = "AvailabilityOutbound")]
        public class AvailabilityOutbound
        {
            [XmlElement(ElementName = "AvailabilityFlight")]
            public List<AvailabilityFlight> AvailabilityFlight { get; set; }
        }
        [XmlRoot(ElementName = "AvailabilityReturn")]
        public class AvailabilityReturn
        {
            [XmlElement(ElementName = "AvailabilityFlight")]
            public List<AvailabilityFlight> AvailabilityFlight { get; set; }
        }
        [XmlRoot(ElementName = "Availability")]
        public class Availability
        {
            [XmlElement(ElementName = "AvailabilityOutbound")]
            public AvailabilityOutbound AvailabilityOutbound { get; set; }
            [XmlElement(ElementName = "AvailabilityReturn")]
            public AvailabilityReturn AvailabilityReturn { get; set; }
        }
        [XmlRoot(ElementName = "AvailabilityFlight")]
        public class AvailabilityFlight
        {
            [XmlElement(ElementName = "airline_rcd")]
            public string Airline_rcd { get; set; }
            [XmlElement(ElementName = "flight_number")]
            public string Flight_number { get; set; }
            [XmlElement(ElementName = "booking_class_rcd")]
            public string Booking_class_rcd { get; set; }
            [XmlElement(ElementName = "boarding_class_rcd")]
            public string Boarding_class_rcd { get; set; }
        }
    }
