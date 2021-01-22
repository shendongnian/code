    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using System.Text;
    namespace FrequencyThingy
    {
        class Program
        {
            static void Main(string[] args)
            {
                string data = @"<items>
                                <item att1=""ABC123"" att2=""uID"" />
                                <item att1=""ABC345"" att2=""uID"" />
                                <item att1=""ABC123"" att2=""uID"" />
                                <item att1=""ABC678"" att2=""uID"" />
                                <item att1=""ABC123"" att2=""uID"" />
                                <item att1=""XYZ123"" att2=""uID"" />
                                <item att1=""XYZ345"" att2=""uID"" />
                                <item att1=""XYZ678"" att2=""uID"" />
                                </items>";
                XDocument doc = XDocument.Parse(data);
                var grouping = doc.Root.Elements().GroupBy(item => item.Attribute("att1").Value);
                foreach (var group in grouping)
                {
                    var groupArray = group.ToArray();
                    Console.WriteLine("Group {0} has {1} element(s).", groupArray[0].Attribute("att1").Value, groupArray.Length);
                }
                Console.ReadKey();
            }
        }
    }
