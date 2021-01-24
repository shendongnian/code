        public static void InsertUser(UserModel user)
        {
            try
            {
                using (_conn = new SqlConnection(_connectionString))
                {
                    _conn.Execute(@"IF EXISTS(SELECT * FROM USER WHERE ID = @ID)
    	                            BEGIN
    		                            /*DO THE UPDATE*/
    	                            END
                                ELSE
    	                            BEGIN
    		                            /*DO THE INSERT*/
    	                            END", user);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
