    public class User
    {
        public string userId { get; set; }
    }
    public List<User> ShowDetailsFromDB()
    {
        using (adoHelper = new AdoHelper(connectionString))
        {
            List<User> users = new List<User>();
            string procedureName = "GetDetails";
            SqlDataReader dataReader = adoHelper.ExecuteDataReaderByProcedure(procedureName);
            while (dataReader.Read())
            {
                User user = new User
                {
                    userId = dataReader[1] as string
                };
                users.Add(user);
                //here I want to assign each object property as list element
            }
            return users;
        }
    }
