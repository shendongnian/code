    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication98
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                Weather weather = new Weather();
                XDocument doc = XDocument.Load(FILENAME);
                XElement current = doc.Descendants("current").FirstOrDefault();
                XElement city = current.Element("city");
                weather.cityID = (string)city.Attribute("id");
                weather.cityName = (string)city.Attribute("name");
                weather.lat = (decimal)city.Element("coord").Attribute("lat");
                weather.lon = (decimal)city.Element("coord").Attribute("lon");
                weather.country  = (string)city.Element("country");
                weather.surnrise = (DateTime)city.Element("sun").Attribute("rise");
                weather.sunset = (DateTime)city.Element("sun").Attribute("set");
                XElement temperature = current.Element("temperature");
                weather.temperature = (decimal)temperature.Attribute("value");
                weather.mintemperature = (decimal)temperature.Attribute("min");
                weather.mintemperature = (decimal)temperature.Attribute("max");
                weather.temperatureUnit = (string)temperature.Attribute("unit");
                XElement humidity = current.Element("humidity");
                weather.humidity = (decimal)humidity.Attribute("value");
                weather.humidityUnit = (string)humidity.Attribute("unit");
                XElement pressure = current.Element("pressure");
                weather.pressure = (decimal)pressure.Attribute("value");
                weather.pressureUnit = (string)pressure.Attribute("unit");
                XElement wind = current.Element("wind");
                weather.windSpeed = (decimal)wind.Element("speed").Attribute("value");
                weather.windType = (string)wind.Element("speed").Attribute("name");
                weather.windDirectionDegrees = (int)wind.Element("direction").Attribute("value");
                weather.windDirectionString = (string)wind.Element("direction").Attribute("name");
                XElement clouds = current.Element("clouds");
                weather.cloudPercentage = (int)clouds.Attribute("value");
                weather.cloudType  = (string)clouds.Attribute("name");
                XElement visibility = current.Element("visibility");
                weather.visibility = (int)visibility.Attribute("value");
                XElement precipitation = current.Element("precipitation");
                weather.precipitation = (string)precipitation.Attribute("mode");
                XElement xLastUpdate = current.Element("lastupdate");
                weather.lastUpdate = (DateTime)xLastUpdate.Attribute("value");
            }
        }
        public class Weather
        {
            public string cityName { get; set; }
            public string cityID { get; set; }
            public decimal lon { get; set; }
            public decimal lat { get; set; }
            public string country { get; set; }
            public DateTime surnrise { get; set; }
            public DateTime sunset { get; set; }
            public decimal temperature { get; set; }
            public decimal mintemperature { get; set; }
            public decimal maxtemperature { get; set; }
            public string temperatureUnit { get; set; }
            public decimal humidity { get; set; }
            public string humidityUnit { get; set; }
            public decimal pressure { get; set; }
            public string pressureUnit { get; set; }
            public decimal windSpeed { get; set; }
            public string windType { get; set; }
            public int windDirectionDegrees { get; set; }
            public string windDirectionString { get; set; }
            public int cloudPercentage { get; set; }
            public string cloudType { get; set;}
            public int visibility { get; set; }
            public string precipitation { get; set; }
            public DateTime lastUpdate { get; set; }
        
        }
      
     
    }
