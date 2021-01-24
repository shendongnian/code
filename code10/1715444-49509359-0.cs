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
                dt.Columns.Add("Parent", typeof(string));
                dt.Columns.Add("Parent Title", typeof(string));
                dt.Columns.Add("Code", typeof(string));
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("Company", typeof(string));
                dt.Columns.Add("Child", typeof(string));
                dt.Columns.Add("Child Title", typeof(string));
                dt.Columns.Add("Content Type", typeof(string));
                dt.Columns.Add("Time Start", typeof(DateTime));
                dt.Columns.Add("Time Finish", typeof(DateTime));
                XDocument doc = XDocument.Load(FILENAME);
                List<XElement> parents = doc.Root.Elements().ToList();
                foreach (XElement parent in parents)
                {
                    try
                    {
                        string parentTagName = (string)parent.Name.LocalName;
                        string parentTitle = (string)parent.Element("Title");
                        string code = (string)parent.Element("Code");
                        string parentName = (string)parent.Element("Name");
                        string company = (string)parent.Element("company");
                        foreach (XElement child in parent.Element("Children").Elements())
                        {
                            try
                            {
                                string childTagName = child.Name.LocalName;
                                string childTitle = (string)child.Element("Title");
                                string contentType = (string)child.Element("ContentType");
                                DateTime timeStarted = (DateTime)child.Element("TimeStarted");
                                DateTime timeFinished = (DateTime)child.Element("TimeFinished");
                                dt.Rows.Add(new object[] {
                                    parentTagName,
                                    parentTitle,
                                    code,
                                    parentName,
                                    company,
                                    childTagName,
                                    childTitle, 
                                    contentType,
                                    timeStarted,
                                    timeFinished
     
                                });
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
    }
