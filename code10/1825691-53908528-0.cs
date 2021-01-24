    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Data;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("BOL ID", typeof(string));
                dt.Columns.Add("BOL Type", typeof(string));
                dt.Columns.Add("BOL Created By", typeof(string));
                dt.Columns.Add("BOL Created Date", typeof(DateTime));
                dt.Columns.Add("BOL Updated By", typeof(string));
                dt.Columns.Add("BOL Updated Date", typeof(DateTime));
                dt.Columns.Add("Reference Number Type", typeof(string));
                dt.Columns.Add("Reference Number Primary", typeof(Boolean));
                dt.Columns.Add("Reference Number ID", typeof(string));
                dt.Columns.Add("Reference Number", typeof(string));
                XDocument doc = XDocument.Load(FILENAME);
                XElement root = doc.Root;
                List<XElement> masterBillOfLadings = root.Elements("MasterBillOfLading").ToList();
                foreach (XElement masterBillOfLading in masterBillOfLadings)
                {
                    string bolId = (string)masterBillOfLading.Attribute("internalId");
                    string bolType = (string)masterBillOfLading.Attribute("type");
                    string bolCreatedBy = (string)masterBillOfLading.Attribute("createBy");
                    DateTime bolCreatedDate = (DateTime)masterBillOfLading.Attribute("createDate");
                    string bolUpdatedBy = (string)masterBillOfLading.Attribute("updateBy");
                    DateTime bolUpdatedDate = (DateTime)masterBillOfLading.Attribute("updateDate");
                    XElement referenceNumbers = masterBillOfLading.Element("ReferenceNumbers");
                    foreach (XElement referenceNumber in referenceNumbers.Elements("ReferenceNumber"))
                    {
                        string referenceNumberType = (string)referenceNumber.Attribute("type");
                        Boolean referenceNumberPrimary = (Boolean)referenceNumber.Attribute("isPrimary");
                        string referenceNumberID = (string)referenceNumber.Attribute("internalId");
                        string referenceNumberStr = (string)referenceNumber;
                        dt.Rows.Add(new object[] {
                            bolId,
                            bolType,
                            bolCreatedBy,
                            bolCreatedDate,
                            bolUpdatedBy,
                            bolUpdatedDate,
                            referenceNumberType,
                            referenceNumberPrimary,
                            referenceNumberID,
                            referenceNumberStr
                        });
                    }
                }
            }
        }
    }
