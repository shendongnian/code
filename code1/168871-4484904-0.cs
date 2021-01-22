    using System;
    using System.Threading;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web;
    using System.Xml;
    using System.Xml.XPath;
    namespace ReverseGeoLookup
    {
     // http://code.google.com/apis/maps/documentation/geocoding/#ReverseGeocoding
        public static string ReverseGeoLoc(string longitude, string latitude,
            out string Address_ShortName,
            out string Address_country,
            out string Address_administrative_area_level_1,
            out string Address_administrative_area_level_2,
            out string Address_administrative_area_level_3,
            out string Address_colloquial_area,
            out string Address_locality,
            out string Address_sublocality,
            out string Address_neighborhood)
        {
            Address_ShortName = "";
            Address_country = "";
            Address_administrative_area_level_1 = "";
            Address_administrative_area_level_2 = "";
            Address_administrative_area_level_3 = "";
            Address_colloquial_area = "";
            Address_locality = "";
            Address_sublocality = "";
            Address_neighborhood = "";
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load("http://maps.googleapis.com/maps/api/geocode/xml?latlng=" + latitude + "," + longitude + "&sensor=false");
                XmlNode element = doc.SelectSingleNode("//GeocodeResponse/status");
                if (element.InnerText == "ZERO_RESULTS")
                {
                    return ("No data available for the specified location");
                }
                else
                {
                    element = doc.SelectSingleNode("//GeocodeResponse/result/formatted_address");
                    string longname="";
                    string shortname="";
                    string typename ="";
                    bool fHit=false;
                    
                    XmlNodeList xnList = doc.SelectNodes("//GeocodeResponse/result/address_component");
                    foreach (XmlNode xn in xnList)
                    {
                        try
                        {
                            longname = xn["long_name"].InnerText;
                            shortname = xn["short_name"].InnerText;
                            typename = xn["type"].InnerText;
                            fHit = true;
                            switch (typename)
                            {
                                //Add whatever you are looking for below
                                case "country":
                                    {
                                        Address_country = longname;
                                        Address_ShortName = shortname;
                                        break;
                                    }
                                case "locality":
                                    {
                                        Address_locality = longname;
                                        //Address_locality = shortname; //Om Longname visar sig innehålla konstigheter kan man använda shortname istället
                                        break;
                                    }
                                case "sublocality":
                                    {
                                        Address_sublocality = longname;
                                        break;
                                    }
                                case "neighborhood":
                                    {
                                        Address_neighborhood = longname;
                                        break;
                                    }
                                case "colloquial_area":
                                    {
                                        Address_colloquial_area = longname;
                                        break;
                                    }
                                case "administrative_area_level_1":
                                    {
                                        Address_administrative_area_level_1 = longname;
                                        break;
                                    }
                                case "administrative_area_level_2":
                                    {
                                        Address_administrative_area_level_2 = longname;
                                        break;
                                    }
                                case "administrative_area_level_3":
                                    {
                                        Address_administrative_area_level_3 = longname;
                                        break;
                                    }
                                default:
                                    fHit = false;
                                    break;
                            }
                            if (fHit)
                            {
                                Console.Write(typename);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("\tL: " + longname + "\tS:" + shortname + "\r\n");
                                Console.ForegroundColor = ConsoleColor.Gray;
                            }
                        }
                        catch (Exception e)
                        {
                            //Node missing either, longname, shortname or typename
                            fHit = false;
                            Console.Write(" Invalid data: ");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("\tX: " + xn.InnerXml + "\r\n");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        
                    }
                    //Console.ReadKey();
                    return (element.InnerText);
                }
            }
            catch (Exception ex)
            {
                return ("(Address lookup failed: ) " + ex.Message);
            }
            }
    }
