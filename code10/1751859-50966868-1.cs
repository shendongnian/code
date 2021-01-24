    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication51
    {
        class Program
        {
            const string FILENAME1 = @"c:\temp\test1.xml";
            const string FILENAME2 = @"c:\temp\test2.xml";
            static void Main(string[] args)
            {
                XDocument doc1 = XDocument.Load(FILENAME1);
                var result1 = doc1.Descendants("PULL").FirstOrDefault()
                    .Elements().Select(x => new { tagName = x.Name.LocalName, value = (string)x }).ToList();
                XDocument doc2 = XDocument.Load(FILENAME2);
                var result2 = doc2.Descendants("PULL").FirstOrDefault()
                    .Elements().Select(x => new { tagName = x.Name.LocalName, value = (string)x }).ToList();
                //use left outer join to combine
                var joins =
                    (from r1 in result1
                         join r2 in result2 on r1.tagName equals r2.tagName into r
                         from r2 in r.DefaultIfEmpty()
                         select new { tagName = r1.tagName, v1 = (r1 == null) ? null : r1.value, v2 = (r2 == null) ? null : r2.value }
                    ).ToList();
                foreach(var join in joins)
                {
                    if (join.v1 == null)
                    {
                        Console.WriteLine("Name : '{0}', Was deleted in File 1, File 2 value '{1}'", join.tagName, join.v2); 
                        continue;
                    }
                    if (join.v2 == null)
                    {
                        Console.WriteLine("Name : '{0}', Was deleted in File 2, File 1 value '{1}'", join.tagName, join.v1);
                        continue;
                    }
                    if (join.v1 == join.v2)
                    {
                        Console.WriteLine("Name : '{0}', is equal in File 1 and File 2, value '{1}'", join.tagName, join.v1);
                        continue;
                    }
                    Console.WriteLine("Name : '{0}', was changed, File 1 value '{1}', File 2 value '{2}'", join.tagName, join.v1, join.v2);
                }
                Console.ReadLine();
               
            }
        }
    }
