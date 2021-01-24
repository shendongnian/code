             byte[] bytes;
            string contenttype;
            string connectionstring = @"Data Source=localhost\SQLEXPRESS;" + "Initial Catalog=foo_database; Integrated Security=SSPI";
            SqlConnection myconnection = new SqlConnection();
            myconnection.ConnectionString = connectionstring;
            string cvsql = "select binarydata,contenttype from customer where customer_id='1'";
            SqlCommand mycommand = new SqlCommand(cvsql, myconnection);
            SqlDataReader myreader;
            try
            {
                myconnection.Open();
                myreader = mycommand.ExecuteReader();
                myreader.Read();
                bytes = (byte[])myreader["binarydata"];
                contenttype = myreader["contenttype "].ToString();
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = contenttype;
                //Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
                Response.BinaryWrite(bytes);
                Response.Flush();
                Response.End();
       }
       catch{
       }
