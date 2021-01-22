        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        using System.IO;
        using System.Xml;
        using System.Data;
        
        namespace DomenNotification
        {
        	class CreateXML
        	{
                public static string Title = "";
                public static string Hosting = "";
                public static string Startdate = "";
                public static string ExpDate = "";
                public static string Username = "";
                public static string Password = "";
        
                public string Title1 { get; set; }
                public string Hosting1 { get; set; }
                public string Startdate1 { get; set; }
                public string ExpDate1 { get; set; }
                public string Username1 { get; set; }
                public string Password1 { get; set; }
        
        
                public string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Notification.xml"; // This is the path of MyDocuments folder of your pc
                  
               //---------------create xml file -----------------------
        
                public bool isXmlExist(string filePath)
                {
                    bool result = false;
                    try
                    {
                        if (File.Exists(filePath))// Checking the file if exist
                        {
                            Startdate = DateTime.Now.ToShortDateString();
                            result = true;
                        }
                        else
                        {
                            XmlDocument doc = new XmlDocument();
                            XmlElement element1 = doc.CreateElement("", "XML", "");
                            doc.AppendChild(element1);
        
                            //--------------creating the node elements
    
                            XmlElement element2 = doc.CreateElement("", "Title", "");
                            element1.AppendChild(element2);
        
                            XmlElement element3 = doc.CreateElement("", "Hosting", "");
                            element1.AppendChild(element3);
        
                            XmlElement element4 = doc.CreateElement("", "StartDate", "");
                            element1.AppendChild(element4);
        
                            XmlElement element5 = doc.CreateElement("", "ExpDate", "");
                            element1.AppendChild(element5);
        
                            XmlElement element6 = doc.CreateElement("", "Username", "");
                            element1.AppendChild(element6);
        
                            XmlElement element7 = doc.CreateElement("", "password", "");
                            element1.AppendChild(element7);
        
                            doc.Save(filePath);
                            Startdate = DateTime.Now.ToShortDateString();
                            //writeXml(filePath);
        
                            result = true;
                        }
                    }
                    catch { result = false; }
                    return result;
                }
    
                    //-------------------Getting the xml data from creating file ---                 
                public DataSet getXmlData(string filePath)
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        if (isXmlExist(filePath))
                        {
                            ds.Clear();
                            ds.ReadXml(filePath);
                            int table = Convert.ToInt32(ds.Tables.Count);
                            for (int i = 0; i <= table; i++)
                            {
                                Title = ds.Tables[i].Rows[0][0].ToString();
                                Hosting = ds.Tables[i].Rows[0][1].ToString();
                                Startdate = ds.Tables[i].Rows[0][2].ToString();
                                ExpDate = ds.Tables[i].Rows[0][3].ToString();
                                Username = ds.Tables[i].Rows[0][4].ToString();
                                Password = ds.Tables[i].Rows[0][5].ToString();
                            }
                            return ds;
                        }
                        return ds;
                    }
                    catch { return ds; }
                }
    
    //------------------- insert the data into created xml file--------------
    
                public bool writeXml(string filePath,string title,string hosting,string sdate,string exdate,string username,string password)
                {
                    bool result = false;
                    Title = title;
                    Hosting = hosting;
                    Startdate = sdate;
                    ExpDate = exdate;
                    Username = username;
                    Password = password;
                    DataSet ds = new DataSet();
                    DataTable dt = new DataTable();
                    ds.Clear();
                    ds.ReadXml(path);
                    int i = 0;
                    i = Convert.ToInt32(ds.Tables[0].Rows.Count) - 1;
                    try
                    {
        
                        dt.Columns.Add("Title");
                        dt.Columns.Add("Hosting");
                        dt.Columns.Add("StartDate");
                        dt.Columns.Add("ExpDate");
                        dt.Columns.Add("Username");
                        dt.Columns.Add("Password");
        
        
                        dt.Rows.Add(dt.NewRow());
                        dt.Rows[i]["Title"] = Title;
                        dt.Rows[i]["Hosting"] = Hosting;
                        dt.Rows[i]["Startdate"] = Startdate;
                        dt.Rows[i]["ExpDate"] = ExpDate;
                        dt.Rows[i]["Username"] = Username;
                        dt.Rows[i]["Password"] = Password;
        
                        ds.Tables.Add(dt);
        
                        ds.WriteXml(path);
                        result = true;
                    }
                    catch { }
                    return result;
                }
        
        	}
        }
