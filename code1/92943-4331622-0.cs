     public static MySqlConnection GetConnection()
        {
            if (_session == null)
            {
                _session = ActiveRecordMediator.GetSessionFactoryHolder().CreateSession(typeof(ActiveRecordBase));
            }
            var connection = (MySqlConnection)_session.Connection;
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            //var connection = new MySqlConnection(Connstr);
            //connection.Open();
            return connection;
        }
        public static void CloseActiveIsession()
        {
            if (_session != null)
            {
                ActiveRecordMediator.GetSessionFactoryHolder().ReleaseSession(_session);
            }
        }
