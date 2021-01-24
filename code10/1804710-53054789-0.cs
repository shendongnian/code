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
                dt.Columns.Add("TxnID", typeof(string));
                dt.Columns.Add("EditSequence", typeof(string));
                dt.Columns.Add("TxnNumber", typeof(string));
                dt.Columns.Add("CustomerRef_ListID", typeof(string));
                dt.Columns.Add("CustomerRef_FullName", typeof(string));
                dt.Columns.Add("RefNumber", typeof(string));
                dt.Columns.Add("Subtotal", typeof(decimal));
                dt.Columns.Add("BalanceRemaining", typeof(decimal));
                dt.Columns.Add("IsPaid", typeof(Boolean));
                dt.Columns.Add("ItemRef_ListID", typeof(string));
                dt.Columns.Add("ItemRef_FullName", typeof(string));
                dt.Columns.Add("Desc", typeof(string));
                dt.Columns.Add("Quantity", typeof(int));
                dt.Columns.Add("Rate", typeof(decimal));
                dt.Columns.Add("Amount", typeof(decimal));
                XDocument doc = XDocument.Load(FILENAME);
                foreach (XElement invoiceRet in doc.Descendants("InvoiceRet"))
                {
                    string txnId = (string)invoiceRet.Element("TxnID");
                    string editSequence = (string)invoiceRet.Element("EditSequence");
                    string txnNumber = (string)invoiceRet.Element("TxnNumber");
                    XElement customerRef = invoiceRet.Element("CustomerRef");
                    string custListId = (string)customerRef.Element("ListID");
                    string custFullName = (string)customerRef.Element("FullName");
                    string refNumber = (string)invoiceRet.Element("RefNumber");
                    decimal subtotal = (decimal)invoiceRet.Element("Subtotal");
                    decimal balance = (decimal)invoiceRet.Element("BalanceRemaining");
                    Boolean? isPaid = (Boolean?)invoiceRet.Element("IsPaid");
                    foreach (XElement invoiceLine in invoiceRet.Elements("InvoiceLineRet"))
                    {
                        string lineListId = (string)invoiceLine.Descendants("ListID").FirstOrDefault();
                        string lineFullName = (string)invoiceLine.Descendants("FullName").FirstOrDefault();
                        string desc = (string)invoiceLine.Element("Desc");
                        int? quantity = (int?)invoiceLine.Element("Quantity");
                        decimal rate = (decimal)invoiceLine.Element("Rate");
                        decimal amount = (decimal)invoiceLine.Element("Amount");
                        dt.Rows.Add(new object[] {
                            txnId, editSequence, txnNumber, custListId, custFullName,
                            refNumber, subtotal, balance, isPaid, 
                            lineListId, lineFullName, desc, quantity, rate, amount 
                        });
                    }
                }
            }
        }
    }
