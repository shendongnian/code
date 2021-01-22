    <%@ WebHandler Language="C#" Class="DownloadAllEvent" %>
    using System;
    using System.Web; 
    using System.Data.SqlClient;
    using System.Data;
    using System.Text;
    using System.IO;
    public class DownloadAllEvent : IHttpHandler
    { 
        const int BUFFERSIZE = 1024;
    
        public bool IsReusable
        {
             get
        {
              return true;
        }
     } 
     public void ProcessRequest(HttpContext context) 
    { 
       HttpResponse response = context.Response; 
       HttpRequest request = context.Request; 
       response.BufferOutput = true;
       response.ContentType = "application/octet-stream";
       response.AddHeader("Content-Disposition", "attachment; filename=Events.csv");
       response.Cache.SetCacheability(HttpCacheability.NoCache);
       //string  csvfile = request.QueryString["csvfile"];
       string strNoofIds = request.QueryString["NoofIds"];
       // declare variables or do something to pass parameter to writecalEntry function
       
       writeCalEntry(response.Output, strguid, sectionid); 
      response.End(); 
     }
       public void writeCalEntry(TextWriter output, string[] strguid,string sectionid)
       {
            DataTable dt = createDataTable();
            DataRow dr;
            
            StringBuilder sbids = new StringBuilder();
                             
                 
             
            // process table if neeed.. use following code to create CSV format string from table
            string separator;      
            
            separator = ","; //default
            
            string quote = "\"";
            //create CSV file
            //StreamWriter sw = new StreamWriter(AbsolutePathAndFileName);
            //write header line
            StringBuilder sb = new StringBuilder();
            int iColCount = dt.Columns.Count;
            for (int i = 0; i < iColCount; i++)
            {
                //sw.Write(TheDataTable.Columns[i]);
                sb.Append(dt.Columns[i]);
                if (i < iColCount - 1)
                {
                    //sw.Write(separator);
                    sb.Append(separator);
                }
            }
            //sw.Write(sw.NewLine);
            sb.AppendLine();
            //write rows
            foreach (DataRow  tempdr in dt.Rows)
            {
                for (int i = 0; i < iColCount; i++)
                {
                    if (!Convert.IsDBNull(tempdr[i]))
                    {
                        string data = tempdr[i].ToString();
                        data = data.Replace("\"", "\\\"");
                        //sw.Write(quote + data + quote);
                        sb.Append(quote + data + quote);
                    }
                    if (i < iColCount - 1)
                    {
                        //sw.Write(separator);
                        sb.Append(separator);
                    }
                }
                //sw.Write(sw.NewLine);
                sb.AppendLine();
            }
            //sw.Close();
            UnicodeEncoding uc = new UnicodeEncoding();
            output.WriteLine(sb);
        
    }
    
    public static DataTable createDataTable()
    {
        DataTable dt = new DataTable("EventsData");
        // create tables as needed which will be converted to csv format.
        return dt;
    }
