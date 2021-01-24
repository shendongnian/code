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
                dt.Columns.Add("ITEM NO.", typeof(int));
                dt.Columns.Add("ITEMCODE", typeof(string));
                dt.Columns.Add("PARTNUMBER.", typeof(string));
                dt.Columns.Add("DESCRIPTION", typeof(string));
                dt.Columns.Add("QTY.", typeof(int));
                XDocument doc = XDocument.Load(FILENAME);
                foreach (XElement bomrow in doc.Descendants("bomrow"))
                {
                    dt.Rows.Add(new object[] {
                        bomrow.Elements("bomcell").Where(x => (int)x.Attribute("col_no") == 0).FirstOrDefault() == null ?
                            null : (int?)bomrow.Elements("bomcell").Where(x => (int)x.Attribute("col_no") == 0).FirstOrDefault().Attribute("value"),
                        bomrow.Elements("bomcell").Where(x => (int)x.Attribute("col_no") == 1).FirstOrDefault() == null ?
                            null : (string)bomrow.Elements("bomcell").Where(x => (int)x.Attribute("col_no") == 1).FirstOrDefault().Attribute("value"),
                        bomrow.Elements("bomcell").Where(x => (int)x.Attribute("col_no") == 2).FirstOrDefault() == null ?
                            null : (string)bomrow.Elements("bomcell").Where(x => (int)x.Attribute("col_no") == 2).FirstOrDefault().Attribute("value"),
                        bomrow.Elements("bomcell").Where(x => (int)x.Attribute("col_no") == 3).FirstOrDefault() == null ?
                            null : (string)bomrow.Elements("bomcell").Where(x => (int)x.Attribute("col_no") == 3).FirstOrDefault().Attribute("value"),
                        bomrow.Elements("bomcell").Where(x => (int)x.Attribute("col_no") == 4).FirstOrDefault() == null ?
                           null : (int?)bomrow.Elements("bomcell").Where(x => (int)x.Attribute("col_no") == 4).FirstOrDefault().Attribute("value")
                    });
                }
            }
        }
    }
