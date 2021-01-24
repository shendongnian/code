    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Data;
    namespace ConsoleApplication86
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                DataTable dt = new DataTable();
                dt.Columns.Add("StockCode", typeof(string));
                dt.Columns.Add("StockDescription", typeof(string));
                dt.Columns.Add("Comment", typeof(string));
                XElement orderDetails = doc.Descendants("OrderDetails").FirstOrDefault();
                DataRow newRow = null;
                foreach(XElement orderDetail in orderDetails.Elements())
                {
     
                    switch (orderDetail.Name.LocalName)
                    {
                        case "StockLine":
                            newRow = dt.Rows.Add();
                            newRow["StockCode"] = (string)orderDetail.Descendants("StockCode").FirstOrDefault();
                            newRow["StockDescription"] = (string)orderDetail.Descendants("StockDescription").FirstOrDefault();
                            break;
                        case "CommentLine":
                               newRow["Comment"] = (string)orderDetail.Descendants("Comment").FirstOrDefault();
                            break;
                    }
                }
                 
             }
     
        }
     
    }
