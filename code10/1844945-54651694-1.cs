        static public List<string[]> ShowDetailsFromDB()
        {
            using (var adoHelper = new AdoHelper(connectionString))
            {
                List<string[]> users = new List<string[]>();
                string procedureName = "GetDetails";
                SqlDataReader dataReader = adoHelper.ExecuteDataReaderByProcedure(procedureName);
                while (dataReader.Read())
                {
                    var user = new User
                    {
                        userId = dataReader[1] as string,
                        password = dataReader[2] as string,
                        userName = dataReader[3] as string,
                        address = dataReader[4] as string,
                        email = dataReader[5] as string,
                        phone = dataReader[6] as string
                    };
                    //here I want to assign each object property as list element
                    users.Add(user.GetPropertiesAuto());
                }
                return users;
            }
        }
