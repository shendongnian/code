    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    namespace ConsoleApplication97
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml"; 
            static void Main(string[] args)
            {
                string xml = File.ReadAllText(FILENAME);
                XDocument doc = XDocument.Parse(xml);
                XElement root = doc.Root;
                XNamespace glsNs = root.GetNamespaceOfPrefix("gls");
                XNamespace cnrNs = root.GetNamespaceOfPrefix("cnr");
                List<XElement> xPatientDems = doc.Descendants(glsNs + "PatientDem").ToList();
                List<PatientDem> patientDems = new List<PatientDem>();
                foreach (XElement xPatientDem in xPatientDems)
                {
                    PatientDem patientDem = new PatientDem();
                    patientDems.Add(patientDem);
                    XElement xPatientId = doc.Descendants(cnrNs + "PatientId").FirstOrDefault();
                    patientDem.patientId = (string)xPatientId.Element(cnrNs + "IdValue");
                    patientDem.patientIdScheme = (string)xPatientId.Element(cnrNs + "IdScheme");
                    patientDem.patientIdType = (string)xPatientId.Element(cnrNs + "IdType");
                    XElement xPatientName = doc.Descendants(cnrNs + "PatientName").FirstOrDefault();
                    patientDem.title = (string)xPatientName.Descendants(cnrNs + "Title").FirstOrDefault();
                    patientDem.givenName = (string)xPatientName.Descendants(cnrNs + "GivenName").FirstOrDefault();
                    patientDem.familyName = (string)xPatientName.Descendants(cnrNs + "FamilyName").FirstOrDefault();
                    patientDem.nameType = (string)xPatientName.Descendants(cnrNs + "NameType").FirstOrDefault();
                    XElement xPatientAddress = doc.Descendants(cnrNs + "PatientAddress").FirstOrDefault();
                    patientDem.addrressLine = xPatientAddress.Descendants(cnrNs + "AddressLine").Select(x => (string)x).ToList();
                    patientDem.postCode = (string)xPatientAddress.Element(cnrNs + "PostCode");
                    patientDem.addressType = (string)xPatientAddress.Element(cnrNs + "AddressType");
                    patientDem.dateOfBirth = (DateTime)xPatientDem.Element(cnrNs + "DateOfBirth");
                    patientDem.sex = (string)xPatientDem.Element(cnrNs + "Sex");
     
                }
            }
        }
        public class PatientDem
        {
           public string patientId { get;set;}
           public string patientIdScheme { get;set;}
           public string patientIdType { get;set;}
           public string title { get;set;}
           public string givenName { get;set;}
           public string familyName { get;set;}
           public string nameType { get; set; }
           public List<string> addrressLine { get;set;}
           public string postCode { get;set;}
           public string addressType { get;set;}
           public DateTime dateOfBirth { get;set;}
           public string sex { get;set;}
        }
    }
