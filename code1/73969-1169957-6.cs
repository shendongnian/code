     protected ConnectionWrapper GetOpenConnection(bool disposeInnerConnection)
        {
            DbConnection connection = TransactionScopeConnections.GetConnection(this);
            if (connection != null)
            {
                return new ConnectionWrapper(connection, false);
            }
            
            return new ConnectionWrapper(GetNewOpenConnection(), disposeInnerConnection);
        }
