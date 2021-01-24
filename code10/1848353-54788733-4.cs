    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Xml;
    using System.Xml.Linq;
    namespace WindowsFormsApplication37
    {
        enum Logic
        {
            AND,
            OR
        }
        public partial class Form1 : Form
        {
            const string LOG_XML_FILENAME = @"c:\temp\test1.xml";
            const string STATUS_XML_FILENAME = @"c:\temp\test2.xml";
            public Form1()
            {
                InitializeComponent();
            }
            private List<StatusCode> statusCodes = new List<StatusCode>();
            private void button1_Click(object sender, EventArgs e)
            {
                DataTable errorLogDatatable = new DataTable();
                errorLogDatatable.Columns.Add("Date", typeof(DateTime));
                errorLogDatatable.Columns.Add("Severity", typeof(string));
                errorLogDatatable.Columns.Add("id", typeof(string));
                errorLogDatatable.Columns.Add("ID", typeof(string));
                errorLogDatatable.Columns.Add("Msg", typeof(string));
                XDocument docLog = XDocument.Load(LOG_XML_FILENAME);
                foreach (XElement log in docLog.Descendants("Log"))
                {
                    DateTime date = (DateTime)log.Attribute("Date");
                    string severity = (string)log.Attribute("Severity");
                    string id = (string)log.Attribute("id");
                    string ID = (string)log.Attribute("ID");
                    string msg = (string)log.Attribute("Msg");
                    errorLogDatatable.Rows.Add(new object[] { date, severity, id, ID, msg });
                }
                XDocument docStatus = XDocument.Load(STATUS_XML_FILENAME);
                Logic logic = Logic.AND;
                foreach (XElement Statuscode in docStatus.Descendants("Statuscode"))
                {
                    StatusCode statusCode = new StatusCode()
                    {
                        Code = (string)Statuscode.Attribute("value"),
                        Text = (string)Statuscode.Attribute("text")
                    };
                    statusCodes.Add(statusCode);
                    DataTable status = null;
                    foreach (XElement trigger in Statuscode.Descendants("Trigger"))
                    {
                        string searchField = (string)trigger.Attribute("searchField");
                        string searchText = (string)trigger.Attribute("searchText");
                        statusCode.Triggers.Add(new Trigger() { SearchField = searchField, SearchText = (string)trigger.Attribute("searchText") });
                    }
                    switch (logic)
                    {
                        case Logic.AND:
                            status = errorLogDatatable.AsEnumerable()
                                .Where(x => statusCode.Triggers.All(field => x.Field<string>(field.SearchField) == field.SearchText))
                                .CopyToDataTable();
                            break;
                        case Logic.OR:
                            status = errorLogDatatable.AsEnumerable()
                                .Where(x => statusCode.Triggers.Any(field => x.Field<string>(field.SearchField) == field.SearchText))
                                .CopyToDataTable();
                            break;
                    }
                    var bindingSource = new BindingSource
                    {
                        DataSource = status,
                    };
                    dataGridView1.DataSource = bindingSource;
     
                }
            }
        }
        class Trigger
        {
            public string SearchField { get; set; }
            public string SearchText { get; set; }
        }
        class StatusCode
        {
            public string Code { get; set; }
            public string Text { get; set; }
            public List<Trigger> Triggers { get; private set; }
            public StatusCode()
            {
                Triggers = new List<Trigger>();
            }
        }
    }
