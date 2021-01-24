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
                var books = doc.Descendants("books").Elements().Select(x => new { book = x, sequence = TestChildren(x) }).Where(x => x.sequence != null).ToList();
            }
            static List<List<XElement>> TestChildren(XElement book)
            {
                List<List<XElement>> results = null;
                List<XElement> children = book.Elements().ToList();
                // get lls, make -1 if not ph
                List<int> lls = children.Select(x => x.Name.LocalName != "ph" ? -1 : int.Parse(((string)x.Attribute("ll")).Substring(1))).ToList();
                //check for 3 in a row incrementing
                int startIndex = -1;
                int numberInSequence = 0;
                for(int i = 0; i < lls.Count() - 3; i++)
                {
                    //test for 3 in a row
                    if ((lls[i] + 1 == lls[i + 1]) && (lls[i] + 2 == lls[i + 2]))
                    {
                        //if first sequency found set start index and lenght to 3
                        if (startIndex == -1)
                        {
                            startIndex = i;
                            numberInSequence = 3;
                        }
                        else
                        {
                            //increase length if more than 3
                            numberInSequence++;
                        }
                    }
                    else
                    {
                        //if a sequence has been found add to results
                        if (numberInSequence >= 3)
                        {
                            List<XElement> sequence = new List<XElement>(children.Skip(startIndex).Take(numberInSequence).ToList());
                            if (results == null) results = new List<List<XElement>>();
                            results.Add(sequence);
                            startIndex = -1;
                            numberInSequence = 0;
                        }
                    }
                }
                if (numberInSequence >= 3)
                {
                    List<XElement> sequence = new List<XElement>(children.Skip(startIndex).Take(numberInSequence).ToList());
                    if (results == null) results = new List<List<XElement>>();
                    results.Add(sequence);
                }
                return results;
            }
        }
    }
