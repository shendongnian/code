    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                string xml = File.ReadAllText(FILENAME);
                XDocument doc = XDocument.Parse(xml);
                XElement getAllCompanyResult = doc.Descendants().Where(x => x.Name.LocalName == "GetAllCompanyResult").FirstOrDefault();
                XNamespace nsA = getAllCompanyResult.GetNamespaceOfPrefix("a");
                List<DTOCtrmSetupCompany> companies = getAllCompanyResult.Elements(nsA + "DTOCtrmSetupCompany").Select(x => new DTOCtrmSetupCompany()
                {
                    Company_Id = (int)x.Element(nsA + "Company_Id"),
                    Last_Modify_Date = (DateTime)x.Element(nsA + "Last_Modify_Date")
                }).ToList();
      
            }
        }
        public class DTOCtrmSetupCompany
        {
            public int Company_Id { get; set; }
            public DateTime Last_Modify_Date { get; set; }
        }
    }
