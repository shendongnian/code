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
            dsXml.ReadXml("mydata.xml");
            for (int i = 0; i < dsXml.Tables.Count; i++)
            {
                Console.WriteLine("Table Name: " + dsXml.Tables[i].TableName);
                DataSet newDataSet = new DataSet();
                newDataSet.Tables.Add(dsXml.Tables[i].Copy());
                FileStream myFileStream = new FileStream(dsXml.Tables[i].TableName + ".xml", FileMode.Create);
                XmlTextWriter myXmlWriter = new XmlTextWriter(myFileStream, Encoding.Default);
                newDataSet.WriteXml(myXmlWriter);
                myXmlWriter.Close();
            }
        }
     }
    }
