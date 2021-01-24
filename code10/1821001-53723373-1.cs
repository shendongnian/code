    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Globalization;
    namespace ConsoleApplication91
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.txt";
            static void Main(string[] args)
            {
                Certificate.Add(FILENAME);
            }
        }
        public enum STATE
        {
            HEADER_FIRST_ROW,
            HEADER_NOT_FIRST_ROW,
            SIGNER_NAME,
            SIGNER_DATA
        }
        public class Certificate
        {
            public static Dictionary<string, Certificate> certificateDictionary = new Dictionary<string, Certificate>();
            public string filename { get;set;}
            public string verified { get; set; }
            public DateTime signingDate1 { get; set; }
            public DateTime signingDate2 { get; set; }
            public string catalog { get; set; }
            public List<Signer> signers { get; set; }
            public static void Add(string filename)
            {
                IFormatProvider provider = CultureInfo.InvariantCulture;
                StreamReader reader = new StreamReader(filename);
                string line = "";
                Certificate certificate = null;
                int dateCount = 0;
                Signer signer = null;
                string name = "";
                string value = "";
                STATE state = STATE.HEADER_FIRST_ROW;
                while ((line = reader.ReadLine()) != null)
                {
                    line = line.Trim();
                    if (line.Length > 0)
                    {
                        switch (state)
                        {
                            case STATE.HEADER_FIRST_ROW:
                                certificate = new Certificate();
                                certificate.filename = line;
                                certificateDictionary.Add(certificate.filename, certificate);
                                dateCount = 0;
                                state = STATE.HEADER_NOT_FIRST_ROW;
                                break;
                            case STATE.HEADER_NOT_FIRST_ROW:
                                name = line.Substring(0, line.IndexOf(":")).Trim();
                                value = line.Substring(line.IndexOf(":") + 1).Trim();
                                switch (name)
                                {
                                    case "Verified":
                                        certificate.verified = value;
                                        break;
                                    case "Signing date":
                                        if (dateCount == 0)
                                        {
                                            dateCount = 1;
                                            certificate.signingDate1 = DateTime.ParseExact(value, "h:mm tt M/dd/yyyy", provider);
                                        }
                                        else
                                        {
                                            certificate.signingDate2 = DateTime.ParseExact(value, "h:mm tt M/dd/yyyy", provider);
                                        }
                                        break;
                                    case "Catalog":
                                        certificate.catalog = value;
                                        break;
                                    case "Signers":
                                        state = STATE.SIGNER_NAME;
                                        break;
                                }
                                break;
                            case STATE.SIGNER_NAME:
                                if(certificate.signers == null) certificate.signers = new List<Signer>();
                                signer = new Signer();
                                certificate.signers.Add(signer);
                                signer.name = line;
                                state = STATE.SIGNER_DATA;
                                break;
                            case STATE.SIGNER_DATA:
                                name = line.Substring(0, line.IndexOf(":")).Trim();
                                value = line.Substring(line.IndexOf(":") + 1).Trim();
                                switch (name)
                                {
                                    case "Cert Status":
                                        signer.certificateStatus = value;
                                        break;
                                    case "Valid Usage":
                                        signer.validUsage = value;
                                        break;
                                    case "Cert Issuer":
                                        signer.certIssuer = value;
                                        break;
                                    case "Serial Number":
                                        signer.serialNumber = value;
                                        break;
                                    case "Thumbprint":
                                        signer.thumbPrint  = value;
                                        break;
                                    case "Valid from":
                                        signer.fromDate = DateTime.ParseExact(value, "h:mm tt M/dd/yyyy", provider);
                                        break;
                                    case "Valid to":
                                        signer.toDate = DateTime.ParseExact(value, "h:mm tt M/dd/yyyy", provider);
                                        state = STATE.SIGNER_NAME;
                                        break;
                                }
                                break;
                        }
                    }
                }
     
            }
            public class Signer
            {
                public string name { get; set; }
                public string certificateStatus { get; set; }
                public string validUsage { get; set; }
                public string certIssuer { get; set; }
                public string serialNumber { get; set; }
                public string thumbPrint { get; set; }
                public DateTime fromDate { get; set; }
                public DateTime toDate { get; set; }
            }
        }
     
    }
