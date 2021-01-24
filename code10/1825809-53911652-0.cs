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
            static void Main(string[] args)
            {
                string header = "<?xml version=\"1.0\" encoding=\"utf-8\" ?><root xmlns:irs=\"myUrl\"></root>";
                XDocument doc = XDocument.Parse(header);
                XElement root = doc.Root;
                XNamespace irs = root.GetNamespaceOfPrefix("irs");
                XElement businessName = new XElement("BusinessNameLine1Txt", "Comp Name");
                root.Add(businessName);
                XElement tinRequest = new XElement(irs + "TINRequestTypeCd");
                root.Add(tinRequest);
                XElement employerEIN = new XElement(irs + "EmployerEIN", "899090900");
                root.Add(employerEIN);
                XElement contactNameGrp = new XElement("ContactNameGrp");
                root.Add(contactNameGrp);
                XElement firstName = new XElement("PersonFirstNm", "First Name Person");
                contactNameGrp.Add(firstName);
                XElement lastName = new XElement("PersonLastNm", "Last Name Person");
                contactNameGrp.Add(lastName);
            }
        }
    }
    //sample output
    //<?xml version="1.0" encoding="utf-8" ?>
    //<root xmlns:irs="myUrl">
    //<BusinessName>
    //  <BusinessNameLine1Txt>Comp Name</BusinessNameLine1Txt>
    //</BusinessName> 
    //<irs:TINRequestTypeCd>BUSINESS_TIN</irs:TINRequestTypeCd> 
    //<irs:EmployerEIN>899090900</irs:EmployerEIN> 
    //<ContactNameGrp>
    //  <PersonFirstNm>First Name Person</PersonFirstNm>
    //  <PersonLastNm>Last Name Person</PersonLastNm>
    //</ContactNameGrp> <ContactPhoneNum>9090909000</ContactPhoneNum>
    //</root>
