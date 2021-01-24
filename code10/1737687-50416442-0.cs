    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication45
    {
        class Program
        {
     
            static void Main(string[] args)
            {
                string xmlIdent = "<?xml version=\"1.0\" encoding=\"utf-16\"?>" +
                    "<GeneralInformation xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">" +
                    "</GeneralInformation>";
                XDocument doc = XDocument.Parse(xmlIdent);
                XElement generalInfo = doc.Root;
                XElement infoList = new XElement("InfoList");
                generalInfo.Add(infoList);
                for (int i = 0; i < 10; i++)
                {
                    infoList.Add(new XElement("Infor" + i.ToString("0##"), new XElement("InfoName", "Test" + i.ToString("0##"))));
                }
                
            }
      
        }
    }
    //<?xml version="1.0" encoding="utf-16"?>
    //<GeneralInformation xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
    //    <InfoList>
    //        <Info001>
    //            <InfoName>Test1</InfoName>
    //        </Info001>
    //        <Info002>
    //            <InfoName>Test2</InfoName>
    //        </Info002>
    //        <Info003>
    //            <InfoName>Test3</InfoName>
    //        </Info003>
    //    </InfoList>
    //</GeneralInformation>
