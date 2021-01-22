    public class PdfHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/pdf";
            var cd = new ContentDisposition();
            cd.FileName = "test.pdf";
            cd.Inline = true;
            context.Response.AddHeader("Content-Disposition", cd.ToString());
            int id;
            if (int.TryParse(context.Request["id"], out id)) 
            {
                id = 0;
            }
            var connectionString = ConfigurationManager.ConnectionStrings["some_db"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = "select image from some_table where image_id = :id";
                command.Parameters.AddWithValue("id", id);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        long bytesRead;
                        int size = 1024;
                        var buffer = new byte[size];
                        long dataIndex = 0;
                        while ((bytesRead = reader.GetBytes(0, dataIndex, buffer, 0, buffer.Length)) > 0)
                        {
                            var actual = new byte[bytesRead];
                            Buffer.BlockCopy(buffer, 0, actual, 0, (int)bytesRead);
                            context.Response.OutputStream.Write(actual, 0, actual.Length);
                            dataIndex += bytesRead;
                        }
                        break;
                    }
                }
            }
        }
        public bool IsReusable
        {
            get { return false; }
        }
    }
