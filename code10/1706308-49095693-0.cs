    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                List<XElement> books = doc.Descendants("books").Elements().Where(x => TestChildren(x)).ToList();
            }
            static Boolean TestChildren(XElement book)
            {
                List<XElement> children = book.Elements().Skip(2).ToList();
                // get lls, make -1 if not ph, get int part of the pXX
                List<int> lls = children.Select(x => x.Name.LocalName != "ph" ? -1 : int.Parse(((string)x.Attribute("ll")).Substring(1))).ToList();
                //check for 3 in a row incrementing
                for(int i = 0; i < lls.Count() - 3; i++)
                {
                    if ((lls[i] + 1 == lls[i + 1]) && (lls[i] + 2 == lls[i + 2]))
                    {
                        return true;
                    }
                }
                return false;
            }
        }
    }
