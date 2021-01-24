    using System;
    using System.Collections.Generic;
    using System.Collections;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication75
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                List<XElement> deleteMe = doc.Descendants().Where(x => (string)x == "DELETE ME").ToList();
                for (int i = deleteMe.Count - 1; i >= 0; i--)
                {
                    deleteMe[i].Remove();
                }
            }
     
        }
     
    }
