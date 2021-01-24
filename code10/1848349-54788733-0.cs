    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication100
    {
        class Program
        {
            const string LOG_XML_FILENAME = @"c:\temp\test1.xml";
            const string STATUS_XML_FILENAME = @"c:\temp\test2.xml";
            static void Main(string[] args)
            {
                DataTable logging = new DataTable();
                logging.Columns.Add("Date", typeof(DateTime));
                logging.Columns.Add("Severity", typeof(string));
                logging.Columns.Add("id", typeof(string));
                logging.Columns.Add("ID", typeof(string));
                logging.Columns.Add("Msg", typeof(string));
                XDocument docLog = XDocument.Load(LOG_XML_FILENAME);
                foreach (XElement log in docLog.Descendants("Log"))
                {
                    DateTime date = (DateTime)log.Attribute("Date");
                    string severity = (string)log.Attribute("Severity");
                    string id = (string)log.Attribute("id");
                    string ID = (string)log.Attribute("ID");
                    string msg = (string)log.Attribute("Msg");
                    logging.Rows.Add(new object[] { date, severity, id, ID, msg });
                }
                
                XDocument docStatus = XDocument.Load(STATUS_XML_FILENAME);
                foreach (XElement Statuscode in docStatus.Descendants("Statuscode"))
                {
                    DataTable status = logging.Clone();
                    foreach (XElement trigger in Statuscode.Descendants("Trigger"))
                    {
                        string searchField = (string)trigger.Attribute("searchField");
                        string searchText = (string)trigger.Attribute("searchText");
                        switch(searchField)
                        {
                            case "Date" :
                                logging.AsEnumerable().Where(x => x.Field<DateTime>(searchField) == (DateTime)trigger.Attribute(searchField)).CopyToDataTable(status, LoadOption.Upsert);
                                break;
                            default:
                                logging.AsEnumerable().Where(x => x.Field<string>(searchField) == searchText).CopyToDataTable(status, LoadOption.Upsert);
                                break;
                        }
                            
                        
                    }
                }
     
            }
        }
    }
