    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Data;
    using System.Data.OleDb;
    using System.IO;
    namespace ConsoleApplication31
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            const string XML_FILENAME = @"c:\temp\text.xls";
            const string SHEET_NAME = "sheet1";
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("ContentDate", typeof(DateTime));
                dt.Columns.Add("Originator", typeof(int));
                dt.Columns.Add("FileContent", typeof(string));
                dt.Columns.Add("RecordCount", typeof(int));
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("OtherEntityName", typeof(string));
                dt.Columns.Add("ID", typeof(string));
                dt.Columns.Add("EntityID", typeof(string));
                dt.Columns.Add("FirstAddressLine", typeof(string));
                dt.Columns.Add("AddressNumber", typeof(string));
                dt.Columns.Add("AdditionalAddressLine", typeof(string));
                dt.Columns.Add("City", typeof(string));
                dt.Columns.Add("Region", typeof(string));
                dt.Columns.Add("Country", typeof(string));
                dt.Columns.Add("PostalCode", typeof(string));
                XDocument doc = XDocument.Load(FILENAME);
                XElement root = doc.Root;
                XNamespace ns = root.GetDefaultNamespace();
                XElement body = root.Element(ns + "Header");
                DateTime contentDate = (DateTime)body.Element(ns + "ContentDate");
                int originator = (int)body.Element(ns + "Originator");
                string fileContent = (string)body.Element(ns + "FileContent");
                int recordCount = (int)body.Element(ns + "RecordCount");
                List<XElement> records = root.Descendants(ns + "Records").FirstOrDefault().Elements().ToList();
                foreach (XElement record in records)
                {
                    XElement entity = record.Element(ns + "Entity");
                    XElement confirmation = entity.Element(ns + "Confirmation");
                    string id = (string)confirmation.Element(ns + "ID");
                    string entityID = (string)confirmation.Element(ns + "EntityID");
                    foreach (XElement address in entity.Elements().Where(x => x.Name.LocalName.Contains("Address")))
                    {
                        DataRow newRow = dt.Rows.Add();
                        newRow["ContentDate"] = contentDate;
                        newRow["Originator"] = originator;
                        newRow["FileContent"] = fileContent;
                        newRow["RecordCount"] = recordCount;
                        newRow["ID"] = id;
                        newRow["EntityID"] = entityID;
                        newRow["Name"] = (string)entity.Element(ns + "Name");
                        newRow["OtherEntityName"] = string.Join(",", entity.Descendants(ns + "OtherEntityName").Select(x => (string)x));
                        XElement xAddress = address;
                        if (xAddress.Name.LocalName == "OtherAddresses") xAddress = address.Element(ns + "OtherAddress");
                        newRow["FirstAddressLine"] = (string)xAddress.Element(ns + "FirstAddressLine");
                        newRow["AddressNumber"] = (string)xAddress.Element(ns + "FirstAddressLine");
                        newRow["AdditionalAddressLine"] = string.Join(",", xAddress.Elements(ns + "FirstAddressLine").Select(x => (string)x));
                        newRow["City"] = (string)xAddress.Element(ns + "City");
                        newRow["Region"] = (string)xAddress.Element(ns + "Region");
                        newRow["Country"] = (string)xAddress.Element(ns + "Country");
                        newRow["PostalCode"] = (string)xAddress.Element(ns + "PostalCode");
                    }
                }
                if(File.Exists(XML_FILENAME)) File.Delete(XML_FILENAME);
                OleDbCommand cmd = new OleDbCommand();
                OleDbDataAdapter adapter = new OleDbDataAdapter();
                string connectionString = string.Format(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Mode=ReadWrite;Extended Properties='Excel 8.0;HDR=Yes;IMEX=0';", XML_FILENAME);
                OleDbConnection conn = new OleDbConnection(connectionString);
     
                conn.Open();
                Boolean firstRow = true;
                string[] columnNames = dt.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToArray();
                cmd = new OleDbCommand();
                cmd.Connection = conn;
                string dataType = "";
                foreach (DataColumn dc in dt.Columns)
                {
                    switch (dc.DataType.Name)
                    {
                        case "Int32" : 
                            dataType = "integer";
                            break;
                        default:
                            dataType = dc.DataType.Name;
                            break;
                    }
                    
                    
                    if (firstRow)
                    {
                        string query = string.Format("CREATE TABLE [{0}] ( [{1}] {2})", SHEET_NAME, dc.ColumnName, dataType);
                        cmd.CommandText = query;
                        
                        cmd.ExecuteNonQuery();
                        firstRow = false;
                    }
                    else
                    {
                        string query = string.Format("Alter TABLE [{0}] ADD [{1}] {2}", SHEET_NAME, dc.ColumnName, dataType);
                        cmd.CommandText = query;
                        cmd.ExecuteNonQuery();
                    }
                }
                string insertQuery = string.Format("INSERT INTO [{0}] ({1}) VALUES ({2});", SHEET_NAME, string.Join(",", columnNames), string.Join(",", dt.Columns.Cast<DataColumn>().Select(x =>  "@" + x.ColumnName)));
                cmd.CommandText = insertQuery;
     
                foreach (DataRow row in dt.AsEnumerable())
                {
                    for(int colNumber = 0; colNumber < dt.Columns.Count; colNumber++)
                    {
                        cmd.Parameters.AddWithValue("@" + dt.Columns[colNumber].ColumnName, row[colNumber].ToString());
                    }
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }
    }
