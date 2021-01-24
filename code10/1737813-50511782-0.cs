    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Data.SqlTypes;
    using Microsoft.SqlServer.Server;
    using System.Collections;
    using System.Globalization;
    // Other things we need for WebRequest
    using System.Net;
    using System.Text;
    using System.IO;
    using System.Text.RegularExpressions;
    
    public partial class StoredProcedures
    {
        [Microsoft.SqlServer.Server.SqlProcedure]
        public static void ApiParser(SqlString uri, SqlString user, SqlString pwd, SqlString postd)
        {
            // Create an SqlPipe to send data back to the caller
            SqlPipe pipe = SqlContext.Pipe;
            //Make sure we have a url to process
            if (uri.IsNull || uri.Value.Trim() == string.Empty)
            {
                pipe.Send("uri cannot be empty");
                return;
            }
        try
        {
            //Create our datatable and get the table structure from the database
            DataTable table = new DataTable();
            string connectionString = null;
            //connectionString = "Data source= 192.168.0.5; Database=Administration; Trusted_Connection=True;";
            connectionString = "Data Source=(localdb)\\ProjectsV12;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection gts = new SqlConnection(connectionString))
            {
                gts.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT TOP 0 * FROM sp_WebSvcs.dbo.JSON_DATA", gts))
                {
                    adapter.Fill(table);
                }
            }
            // Send a message string back to the client.
            pipe.Send("Beginning Api Call...");
            String json = "";
            // Set up the request, including authentication
            WebRequest req = HttpWebRequest.Create(uri.Value);
            if (!user.IsNull & user.Value != "")
            {
                req.Credentials = new NetworkCredential(user.Value, pwd.Value);
            }
            ((HttpWebRequest)req).UserAgent = "CLR web client on SQL Server";
            // Fire off the request and retrieve the response.
            using (WebResponse resp = req.GetResponse())
            {
                using (Stream dataStream = resp.GetResponseStream())
                {
                    using (StreamReader rdr = new StreamReader(dataStream))
                    {
                        json = (String)rdr.ReadToEnd();
                        rdr.Close();
                    }
                    // Close up everything...
                    dataStream.Close();
                }
                resp.Close();
            }//end using resp
            pipe.Send("Api Call complete; Parsing returned data...");
            int i = 0;
            String h = "";
            String l = "";
            int s = 0;
            int p = 0;
            int b = 0;
            int payload = 0;
            foreach (string line in json.Split(new[] { "}," }, StringSplitOptions.None))
            {
                if (line != "")
                {
                    l = line;
                    i = l.Replace("{", "").Length + 1;
                    p = l.LastIndexOf("{");
                    if (line.Length > i) //we find this at the beginning of a group of arrays
                    {
                        h = line.Substring(0, p - 1);
                        s = Math.Max(0, h.LastIndexOf("{"));
                        if (h.Length > s && s != 0)
                        /*We have a nested array that has more than one level.
                         *This should only occur at the beginning of new array group.
                         *Advance the payload counter and get the correct string from line.*/
                        {
                            payload++;
                            l = line.Substring(s, line.Length - s);
                        }
                        h = (s >= 0) ? h.Substring(0, s) : h;
                        //=============
                        /*At this point 'h' is a nest collection. Split and add to table.*/
                        string[] OrderedNest = h.Split('{');
                        for (int z = 0; z < OrderedNest.Length; z++)
                        {
                            if (OrderedNest[z] != "")
                            {
                                table.Rows.Add(payload, "{" + OrderedNest[z].Replace(":", "").Replace("[","").Replace("]","") + "}");
                            }
                        }
                        //=============
                    }
                    else
                    {
                        h = null;
                    }
                    //at this point the first character in the row should be a "{"; If not we need to add one.
                    if (l[0].ToString() != "{")
                    {
                        l = "{" + l;
                    }
                    
                    if (l.Replace("{", "").Length != l.Replace("}", "").Length) //opening and closing braces don't match; match the closing to the opening
                    {
                        l = l.Replace("}", "");
                        
                        b = l.Length - l.Replace("{", "").Length;
                       
                        l = l + new String('}', b);
                    }
                    table.Rows.Add(payload, l.Replace("\\\"", "").Replace("\\", "").Replace("]","").Replace("[",""));
                }
            }
            //====
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                cnn.Open();
                using (SqlBulkCopy copy = new SqlBulkCopy(cnn))
                {
                    copy.DestinationTableName = "sp_WebSvcs.dbo.JSON_DATA";
                    copy.WriteToServer(table);
                }
            }
            //====
           
        } //end try
        catch (Exception e)
        {
            pipe.Send("We have a problem!");
            throw new Exception("\n\n" + e.Message + "\n\n");
        }
        pipe.Send("Parsing complete");
    }
   
}
