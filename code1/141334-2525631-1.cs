    using System;
    using System.Xml.Linq;
    using System.Xml.XPath;
    using System.Xml;
    namespace XPathExpt
    {
     class Program
     {
       static void Main(string[] args)
       {
         XElement cfg = XElement.Parse(
           @"<configuration>
              <MyNode xmlns=""lcmp"" attr=""true"">
                <subnode />
              </MyNode>
             </configuration>");
         XmlNameTable nameTable = new NameTable();
         var nsMgr = new XmlNamespaceManager(nameTable);
         // Tell the namespace manager about the namespace
         // of interest (lcmp), and give it a prefix (pfx) that we'll
         // use to refer to it in XPath expressions. 
         // Note that the prefix choice is pretty arbitrary at 
         // this point.
         nsMgr.AddNamespace("pfx", "lcmp");
         foreach (var el in cfg.XPathSelectElements("//pfx:MyNode", nsMgr))
         {
             Console.WriteLine("Found element named {0}", el.Name);
         }
       }
     }
    }
