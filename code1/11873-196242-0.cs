    using System;
    using System.Xml.Linq;
    using System.IO;
      
    namespace ConsoleApplication1 {
     class Program {
      static void Main(string[] args) {
       string unformattedXml = "<?xml version=\"1.0\"?><book><author>Lewis, C.S.</author><title>The Four Loves</title></book>";
       XElement doc = XElement.Parse(unformattedXml);
       Console.WriteLine(doc.ToString());
       doc.Save(@"C:\doc.xml");
       Console.WriteLine(File.ReadAllText(@"C:\doc.xml"));
      }
     }
    }
