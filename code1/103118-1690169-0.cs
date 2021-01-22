    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using System.Text;
    namespace MyTestApp
    {
    class Program
    {
        static void Main(string[] args)
        {
            XDocument myXML = XDocument.Load(@"C:\file.xml"); 
            (from c in myXML.Descendants("field")
             where c.Attribute("required")
                   .GetAttributeValueOrDefault("N") == "Y" && 
                    c.Parent.Attribute("id").Value == "P"      
             select 
             c.Attribute("name").Value).ToList().ForEach(s => Console.WriteLine(s.ToString()));
            Console.ReadLine();
        }
    }
    public static class XLinqHelper
    {
        // extension method that handles an xattribute and returns the provided default if the Xattrib is null
        public static string GetAttributeValueOrDefault(this XAttribute s, string defaultValue)
        {
            string retVal;
            if (s == null)
                retVal = defaultValue;
            else
                retVal = s.Value;
            return retVal;
        }
    }
}
