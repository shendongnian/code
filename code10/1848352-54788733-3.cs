    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Serialization;
    namespace ConsoleApplication100
    {
        enum Logic
        {
            AND,
            OR
        }
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
                Logic logic = Logic.AND;
                foreach (XElement Statuscode in docStatus.Descendants("Statuscode"))
                {
                    DataTable status = null;
                    List<KeyValuePair<string, object>> searchFields = new List<KeyValuePair<string, object>>();
                    foreach (XElement trigger in Statuscode.Descendants("Trigger"))
                    {
                        string searchField = (string)trigger.Attribute("searchField");
                        string searchText = (string)trigger.Attribute("searchText");
                        switch(searchField)
                        {
                            case "Date" :
                                searchFields.Add(new KeyValuePair<string, object>(searchField, (DateTime)trigger.Attribute("searchText")));
                                break;
                            default:
                                searchFields.Add(new KeyValuePair<string, object>(searchField, (string)trigger.Attribute("searchText")));
                                break;
                        }
                    }
                    switch (logic)
                    {
                        case Logic.AND :
                            status = logging.AsEnumerable()
                                .Where(x => searchFields.All(field => (field.Value.GetType() == typeof(DateTime)) ? x.Field<DateTime>(field.Key) == (DateTime)field.Value : x.Field<string>(field.Key) == (string)field.Value))
                                .CopyToDataTable();
                            break;
                        case Logic.OR:
                            status = logging.AsEnumerable()
                                .Where(x => searchFields.Any(field => (field.Value.GetType() == typeof(DateTime)) ? x.Field<DateTime>(field.Key) == (DateTime)field.Value : x.Field<string>(field.Key) == (string)field.Value))
                                .CopyToDataTable();
                            break;
                    }
     
                }
            }
        }
    }
