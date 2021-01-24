    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Data;
    namespace ConsoleApplication100
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.csv";
            static void Main(string[] args)
            {
                //|ID    |SN| | Date | Code |Comp|Source|        Format          |Unit|BuyQTY|DoneQTY|YetQTY|Late
                DataTable dt = new DataTable();
                dt.Columns.Add("ID", typeof(string));
                dt.Columns.Add("SN", typeof(string));
                dt.Columns.Add("Date", typeof(string));
                dt.Columns.Add("Code", typeof(string));
                dt.Columns.Add("Comp", typeof(string));
                dt.Columns.Add("Source", typeof(string));
                dt.Columns.Add("Format", typeof(string));
                dt.Columns.Add("Unit", typeof(string));
                dt.Columns.Add("BuyQTY", typeof(int));
                dt.Columns.Add("DoneQTY", typeof(int));
                dt.Columns.Add("YetQTY", typeof(int));
                dt.Columns.Add("Late", typeof(int));
                StreamReader reader = new StreamReader(FILENAME, Encoding.Unicode);
                string line = "";
                int lineCount = 0;
                while((line = reader.ReadLine()) != null)
                {
                    if ((++lineCount > 1) && (line.Trim().Length > 0))
                    {
                        string leader = line.Substring(0, 30).Trim();
                        string source = line.Substring(31, 16).Trim();
                        string trailer = line.Substring(48).TrimStart();
                        string format = trailer.Substring(0, 12).TrimStart();
                        trailer = trailer.Substring(12).Trim();
                        DataRow newRow = dt.Rows.Add();
                        string[] splitLeader = leader.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                        newRow["ID"] = splitLeader[0].Trim();
                        newRow["SN"] = splitLeader[1].Trim();
                        newRow["Date"] = splitLeader[2].Trim();
                        newRow["Code"] = splitLeader[3].Trim();
                        newRow["Comp"] = splitLeader[4].Trim();
                        newRow["Source"] = source;
                        newRow["Format"] = format;
                        newRow["Unit"] = trailer.Substring(0,4).Trim();
                        newRow["BuyQTY"] = int.Parse(trailer.Substring(4, 8));
                        string doneQTYstr = trailer.Substring(12, 8).Trim();
                        if (doneQTYstr.Length > 0)
                        {
                            newRow["DoneQTY"] = int.Parse(doneQTYstr);
                        }
                        if (trailer.Length <= 28)
                        {
                            newRow["YetQTY"] = int.Parse(trailer.Substring(20));
                        }
                        else
                        {
                            newRow["YetQTY"] = int.Parse(trailer.Substring(20,8));
                            newRow["late"] = int.Parse(trailer.Substring(28));
                        }
                    }
                }
            }
        }
    }
