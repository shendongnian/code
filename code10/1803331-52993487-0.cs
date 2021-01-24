    using System;
    using System.Collections.Generic;
    using System.Collections;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication75
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                var status = doc.Descendants("Segment").Select(x => new
                {
                    flightNumber = (string)x.Descendants("FlightNumber").FirstOrDefault(),
                    carrierCode = (string)x.Descendants("CarrierCode").FirstOrDefault(),
                    liftStatus = x.Descendants("LiftStatus").Select(y => (string)y).ToList()
                }).ToList();
            }
     
        }
    }
