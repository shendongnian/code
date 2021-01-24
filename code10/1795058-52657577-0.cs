    using System;
    using System.Xml;
    					
    public class Program
    {
    	public static void Main()
    	{
            XmlDocument doc = new XmlDocument();            
            doc.Load("input.xml");
    
            var nsmgr = new XmlNamespaceManager(doc.NameTable);
            nsmgr.AddNamespace("ns", "urn:oasis:names:tc:evs:schema:eml");
    
            XmlNode testNode = doc.SelectSingleNode("/ns:EML/ns:EMLHeader/ns:ManagingAuthority/ns:Description", nsmgr);
            if (testNode != null)
            {
                Console.WriteLine(testNode.InnerText);
            }
        }
    }
