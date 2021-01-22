    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Xml;
    using System.IO;
    namespace ConsoleApplication1
    {
    class Program
     {
        static void Main(string[] args)
        {
            DataSet dsXml = new DataSet();
            dsXml.ReadXml("http://www.w3schools.com/xml/cd_catalog.xml");
            for (int i = 0; i < dsXml.Tables.Count; i++)
            {
                Console.WriteLine("Table Name: " + dsXml.Tables[i].TableName);
                int j = 1;
                foreach (DataRow myRow in dsXml.Tables[i].Rows)
                {
                    Console.Write("[" + j++ + "]");
                    foreach (DataColumn myColumn in dsXml.Tables[i].Columns)
                    {
                        if (myColumn.ColumnName.Equals("TITLE"))
                            Console.Write("[" + myRow[myColumn] + "]");
                    }
                    Console.WriteLine("");
                }
            }
        }
     }
    }
