    public class DAL
    {
        private readonly IConfiguration config;
    
        public DAL(IConfiguration config)
        {
            this.config = config;
        }
    
        public List<Uservaluesfull> GetUservalues(string SID)
        {
            string PathwayConnString = config.GetConnectionString("PathwayConnString");
    
            //var SID = user.FindFirst("onprem_sid")?.Value;
            List<Uservaluesfull> values = new List<Uservaluesfull>();
            using (SqlConnection myConnection = new SqlConnection(PathwayConnString))
            {
                SqlCommand myCommand = new SqlCommand("usp_GetUserInfo", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter SIDParameter = myCommand.Parameters.Add("SID", SqlDbType.NVarChar, 100);
                SIDParameter.Value = SID;
    
                myConnection.Open();
    
                using (SqlDataReader oReader = myCommand.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        Uservaluesfull s = new Uservaluesfull();
                        DATA here
    
                        values.Add(s);
                    }
                    myConnection.Close();
                }
            }
            return values;
    
        }
    }
