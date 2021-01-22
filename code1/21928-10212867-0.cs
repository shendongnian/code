      private static readonly string _connectionString = ConnectionString.GetDbConnection();
        private const string inserttStr = @"INSERT INTO dbo.testTable (col1) VALUES(@test);";
            /// <summary>
            /// Execute command on DBMS.
            /// </summary>
            /// <param name="command">Command to execute.</param>
            private void ExecuteNonQuery(IDbCommand command)
            {
                if (command == null)
                    throw new ArgumentNullException("Parameter 'command' can't be null!");
                using (IDbConnection connection = new SqlConnection(_connectionString))
                {
                    command.Connection = connection;
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            public void FirstMethod()
            {
                IDbCommand command = new SqlCommand(inserttStr);
                command.Parameters.Add(new SqlParameter("@test", "Hello1"));
                 
                    ExecuteNonQuery(command);
                  
            }
            public void SecondMethod()
            {
                IDbCommand command = new SqlCommand(inserttStr);
                command.Parameters.Add(new SqlParameter("@test", "Hello2"));
                 
                    ExecuteNonQuery(command);
                  
            }
            public void ThirdMethodCauseNetException()
            {
                IDbCommand command = new SqlCommand(inserttStr);
                command.Parameters.Add(new SqlParameter("@test", "Hello3"));
                 
                    ExecuteNonQuery(command);
                int a = 0;
                int b = 1/a;
            }
        public void MainWrap()
        {
            
            TransactionOptions tso = new TransactionOptions();
            tso.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            //TransactionScopeOption.Required, tso
            try
            {
                using (TransactionScope sc = new TransactionScope())
                {
                    FirstMethod();
                    SecondMethod();
                    ThirdMethodCauseNetException();
                    sc.Complete();
                }
            }
            catch (Exception ex)
            {
                logger.ErrorException("eee ",ex);
            }
        }
