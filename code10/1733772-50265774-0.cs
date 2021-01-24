    using System;
    using System.IO;
    using System.Xml;
    
    public class SampleXML
    {
      public static void Main()
      {
        //Create the XmlDocument.
        XmlDocument doc = new XmlDocument();
        doc.Load("TaskName.xml");
    
        //Display the desired tag.
        XmlNodeList elemList = doc.GetElementsByTagName("name");
        for (int i=0; i < elemList.Count; i++)
        {   
          Console.WriteLine(elemList[i].InnerXml);
        }  
    
      }
    }
