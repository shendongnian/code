    public class IISHandler1 : IHttpHandler
    {
        public bool IsReusable
        {
            get { return true; }
        }
        public void ProcessRequest(HttpContext context)
        {
            int theID;
            if (!int.TryParse(context.Request.QueryString["id"], out theID))
                throw new ArgumentException("No parameter specified");
            context.Response.ContentType = "image/jpeg"; // or gif/png depending on what type of image you have
            Stream strm = DisplayImage(theID);
            byte[] buffer = new byte[2048];
            int byteSeq = strm.Read(buffer, 0, 2048);
            while (byteSeq > 0)
            {
                context.Response.OutputStream.Write(buffer, 0, byteSeq);
                byteSeq = strm.Read(buffer, 0, 2048);
            }
        }
        public Stream DisplayImage(int theID)
        {
            try
            {
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString());
                string sql = "SELECT image FROM Table1 WHERE id = @ID";
                using (SqlCommand cmd = new SqlCommand(sql, connection) { CommandType = CommandType.Text })
                {
                    cmd.Parameters.AddWithValue("@ID", theID);
                    connection.Open();
                    object theImg = cmd.ExecuteScalar();
                    return new MemoryStream((byte[]) theImg);
                }
            }
            catch
            {
                return null;
            }
        }
    }
