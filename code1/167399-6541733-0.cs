        public Constructor(string connString, CogTrkDBLog logWriter0)
        {
            connectionString = connString;
            logWriter = logWriter0;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT is_broker_enabled FROM sys.databases WHERE name = 'cogtrk'", conn))
                {
                    bool r = (bool) cmd.ExecuteScalar();
                    if (!r)
                    {
                        throw new Exception("is_broker_enabled was false");
                    }
                }
            }
            if (!CanRequestNotifications())
            {
                throw new Exception("Not enough permission to run");
            }
            // Remove any existing dependency connection, then create a new one.
            SqlDependency.Stop(connectionString);
            SqlDependency.Start(connectionString);
            if (connection == null)
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
            }
            if (command == null)
            {
                command = new SqlCommand(GetSQL(), connection);
            }
            GetData(false);
            GetData(true);
        }
        private string GetSQL()
        {
            return "SELECT id, command, state, value " +
            " FROM dbo.commandqueue WHERE state = 0 ORDER BY id";
        }
        void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            // Remove the handler, since it is only good
            // for a single notification.
            SqlDependency dependency = (SqlDependency)sender;
            dependency.OnChange -= dependency_OnChange;
            GetData(true);
        }
        void GetData(bool withDependency)
        {
            lock (this)
            {
                bool repeat = false;
                do {
                    repeat = false;
                    try
                    {
                        GetDataRetry(withDependency);
                    }
                    catch (SqlException)
                    {
                        if (withDependency) {
                            GetDataRetry(false);
                            repeat = true;
                        }
                    }
                } while (repeat);
            }
        }
        private void GetDataRetry(bool withDependency)
        {
            // Make sure the command object does not already have
            // a notification object associated with it.
            command.Notification = null;
            // Create and bind the SqlDependency object
            // to the command object.
            if (withDependency)
            {
                SqlDependency dependency = new SqlDependency(command);
                dependency.OnChange += dependency_OnChange;
            }
            Console.WriteLine("Getting a batch of commands");
            // Execute the command.
            using (SqlDataReader reader = command.ExecuteReader())
            {
                using (CommandQueueDb db = new CommandQueueDb(connectionString))
                {
                    foreach (CommandEntry c in db.Translate<CommandEntry>(reader))
                    {
                        Console.WriteLine("id:" + c.id);
                        c.state = 1;
                        db.SubmitChanges();
                    }
                }
            }
        }
