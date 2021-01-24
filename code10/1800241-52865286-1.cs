    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {            
                string city = "Los Angeles";
                string query = String.Format("https://query.yahooapis.com/v1/public/yql?q=select * from weather.forecast where woeid in (select woeid from geo.places(1) where text='{0}')&format=xml&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys", city);
                XDocument wData = XDocument.Load(query);
                XNamespace ns = wData.Root.GetDefaultNamespace();
                XElement xWind = wData.Descendants().Where(x => x.Name.LocalName == "wind").FirstOrDefault();
                int speed = (int)xWind.Attribute("speed");
                XElement xLocation = wData.Descendants().Where(x => x.Name.LocalName == "location").FirstOrDefault();
                string town = (string)xLocation.Attribute("city");
                XElement xCondition = wData.Descendants().Where(x => x.Name.LocalName == "condition").FirstOrDefault();
                int temp = (int)xCondition.Attribute("temp");
                XElement xAtmosphere = wData.Descendants().Where(x => x.Name.LocalName == "atmosphere").FirstOrDefault();
                int humidity = (int)xAtmosphere.Attribute("humidity");
                List<XElement> xForecast = wData.Descendants().Where(x => x.Name.LocalName == "forecast").ToList(); ;
                string tfCond = (string)xForecast.FirstOrDefault().Attribute("text");
                int high = (int)xForecast.FirstOrDefault().Attribute("high");
                int low = (int)xForecast.FirstOrDefault().Attribute("low");
           }
      
        }
     
     
    }
