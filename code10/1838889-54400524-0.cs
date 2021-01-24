    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Data;
    namespace ConsoleApplication98
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                DataTable dt1 = new DataTable();
                dt1.Columns.Add("name", typeof(string));
                dt1.Columns.Add("weight", typeof(decimal));
                dt1.Columns.Add("sg", typeof(decimal));
                dt1.Columns.Add("volume", typeof(decimal));
                DataTable dt2 = new DataTable();
                dt2.Columns.Add("name", typeof(string));
                dt2.Columns.Add("volume", typeof(decimal));
                dt2.Columns.Add("x", typeof(decimal));
                dt2.Columns.Add("y", typeof(decimal));
                dt2.Columns.Add("z", typeof(decimal));
                XDocument doc = XDocument.Load(FILENAME);
                foreach (XElement tank in doc.Descendants("Tank"))
                {
                    string name = (string)tank.Attribute("Name");
                    decimal weight = (decimal)tank.Attribute("Weight");
                    decimal sg = (decimal)tank.Attribute("SG");
                    decimal volumnMax = (decimal)tank.Attribute("VolumeMax");
                    dt1.Rows.Add(new object[] { name, weight, sg, volumnMax });
                    foreach (XElement volume in tank.Descendants("Volume"))
                    {
                        decimal value = (decimal)volume.Attribute("Value");
                        if (value != (decimal)0.00)
                        {
                            decimal x = (decimal)volume.Attribute("X");
                            decimal y = (decimal)volume.Attribute("Y");
                            decimal z = (decimal)volume.Attribute("Z");
                            dt2.Rows.Add(new object[] { name, value, x, y, z });
                        }
                    }
                }
     
            }
        }
     
    }
