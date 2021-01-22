    public class TestHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            using (var connection = new SqlConnection(ConnectionString))
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = "NameOfYourSP";
                command.CommandType = CommandType.StoredProcedure;
                foreach (string name in context.Request.Form.Keys)
                {
                    command.Parameters.AddWithValue("@" + name, context.Request.Form[name]);
                }
                command.ExecuteNonQuery();
            }
            context.Response.ContentType = "text/plain";
            context.Response.Write("success");
        }
        public bool IsReusable
        {
            get { return false; }
        }
    }
