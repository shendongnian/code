      public static DbConnection GetConnection(Database db)
        {
            Transaction currentTransaction = Transaction.Current;
            if (currentTransaction == null)
                return null;
            Dictionary<string, DbConnection> connectionList;
            DbConnection connection;
            lock (transactionConnections)
            {
                if (!transactionConnections.TryGetValue(currentTransaction, out connectionList))
                {
                    // We don't have a list for this transaction, so create a new one
                    connectionList = new Dictionary<string, DbConnection>();
                    transactionConnections.Add(currentTransaction, connectionList);
                    // We need to know when this previously unknown transaction is completed too
                    currentTransaction.TransactionCompleted += OnTransactionCompleted;
                }
            }
            lock (connectionList)
            {
                // Next we'll see if there is already a connection. If not, we'll create a new connection and add it
                // to the transaction's list of connections.
                // This collection should only be modified by the thread where the transaction scope was created
                // while the transaction scope is active.
                // However there's no documentation to confirm this, so we err on the safe side and lock.
                if (!connectionList.TryGetValue(db.ConnectionString, out connection))
                {
                    // we're betting the cost of acquiring a new finer-grained lock is less than 
                    // that of opening a new connection, and besides this allows threads to work in parallel
                    connection = db.GetNewOpenConnection();
                    connectionList.Add(db.ConnectionString, connection);
                }
            }
            return connection;
        }
