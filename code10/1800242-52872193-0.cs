    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Xml;
    using System.Xml.Linq;
    using System.Threading;
    namespace WindowsFormsApplication23
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                string[] cities = { "Los Angeles", "New York", "Salem", "Portland", "Washington" };
                DataTable dt = GetWeather(cities);
                dataGridView1.DataSource = dt;
            }
            DataTable GetWeather(string[] cities)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("City", typeof(string));
                dt.Columns.Add("Region", typeof(string));
                dt.Columns.Add("Humidity", typeof(int));
                dt.Columns.Add("Wind Speed", typeof(int));
                dt.Columns.Add("Temperature", typeof(int));
                dt.Columns.Add("Condition", typeof(string));
                dt.Columns.Add("High Temperature", typeof(int));
                dt.Columns.Add("Low Temperature", typeof(int));
                
                foreach (string inputCity in cities)
                {
                    String query = String.Format("https://query.yahooapis.com/v1/public/yql?q=select * from weather.forecast where woeid in (select woeid from geo.places(100) where text='{0}')&format=xml&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys", inputCity);
                    XDocument wData = XDocument.Load(query);
                    XNamespace ns = wData.Root.GetDefaultNamespace();
                    //System.Threading.Thread.Sleep(10000);
                    foreach (XElement channel in wData.Descendants().Where(x => x.Name.LocalName == "channel"))
                    {
                        string city = "";
                        string region = "";
                        int? humidity = null;
                        int? speed = null;
                        int? temp = null;
                        string tfCond = "";
                        int? high = null;
                        int? low = null;
                         XNamespace yWeatherNs = channel.Elements().First().GetNamespaceOfPrefix("yweather");
                        XElement xLocation = channel.Element(yWeatherNs + "location");
                        if (xLocation == null)
                        {
                            continue;
                        }
                        else
                        {
                            city = (string)xLocation.Attribute("city");
                            region = (string)xLocation.Attribute("region");
                        }
                        XElement xAtmosphere = channel.Element(yWeatherNs + "atmosphere");
                        if (xAtmosphere != null)
                        {
                            humidity = (int)xAtmosphere.Attribute("humidity");
                        }
                        XElement xWind = channel.Element(yWeatherNs + "wind");
                        if (xWind != null)
                        {
                            speed = (int)xWind.Attribute("speed");
                        }
                        XElement item = channel.Element("item");
                        if (item != null)
                        {
                            XElement xCondition = item.Element(yWeatherNs + "condition");
                            if (xCondition != null)
                            {
                                temp = (int)xCondition.Attribute("temp");
                            }
                            List<XElement> xForecast = item.Elements(yWeatherNs + "forecast").ToList(); ;
                            if (xForecast != null)
                            {
                                tfCond = (string)xForecast.FirstOrDefault().Attribute("text");
                                high = (int)xForecast.FirstOrDefault().Attribute("high");
                                low = (int)xForecast.FirstOrDefault().Attribute("low");
                            }
                        }
                        dt.Rows.Add(new object[] { city, region, humidity, speed, temp, tfCond, high, low });
                    }                
                }
                dt = dt.AsEnumerable().OrderBy(x => x.Field<string>("City")).ThenBy(x => x.Field<string>("Region")).CopyToDataTable();
                return dt;
            }
        }
    }
