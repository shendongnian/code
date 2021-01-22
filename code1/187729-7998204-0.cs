    [WebService(Description = "Web services to query the book database.", Namespace ="http://www.your-site-url.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ScriptService]
    public class AjaxService: System.Web.Services.WebService
    {
    
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public bool CheckUsernameAvailability(string userName, Options options)
        {
            return this.WriteToSql(options);
        }
        private bool WriteToSql(Options options)
        {
            bool result = false;
            
            try
            {
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString);
                SqlCommand command = new SqlCommand("INSERT_OPTION", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Option1", SqlDbType.NVarChar, 20).Value = options.Option1;
                command.Parameters.Add("@Optoin2", SqlDbType.Bit).Value = (options.Option2 == true ) ? 1 : 0;
            
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                result = true;
            }
            catch(Exception ex)
            {
                //do some logging here...
                result = false;
            }
            return result;
        }
    }
    
    [Serializable]
    public class Options
    {
        public string Option1 { get; set; }
        public bool Option2 { get; set; }
    }
