    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data;
    
    namespace DataAccessLayer
    {
        /// <summary>
        /// Decorator for the connection class, exposing additional info like it's transaction.
        /// </summary>
        public class ConnectionWithExtraInfo : IDbConnection
        {
            private IDbConnection connection = null;
            private IDbTransaction transaction = null;
    
            public IDbConnection Connection
            {
                get { return connection; }
            }
    
            public IDbTransaction Transaction
            {
                get { return transaction; }
            }
    
            public ConnectionWithExtraInfo(IDbConnection connection)
            {
                this.connection = connection;
            }
        
            #region IDbConnection Members
    
            public IDbTransaction BeginTransaction(IsolationLevel il)
            {
                transaction = connection.BeginTransaction(il);
                return transaction;
            }
    
            public IDbTransaction BeginTransaction()
            {
                transaction = connection.BeginTransaction();
                return transaction;
            }
    
            public void ChangeDatabase(string databaseName)
            {
     	        connection.ChangeDatabase(databaseName);
            }
    
            public void Close()
            {
     	        connection.Close();
            }
    
            public string ConnectionString
            {
    	        get 
    	        {
                    return connection.ConnectionString; 
    	        }
    	        set 
    	        {
                    connection.ConnectionString = value;
    	        }
            }
    
            public int ConnectionTimeout
            {
                get { return connection.ConnectionTimeout; }
            }
    
            public IDbCommand CreateCommand()
            {
                return connection.CreateCommand();
            }
    
            public string Database
            {
                get { return connection.Database; }
            }
    
            public void Open()
            {
                connection.Open();
            }
    
            public ConnectionState State
            {
                get { return connection.State; }
            }
    
            #endregion
    
            #region IDisposable Members
    
            public void Dispose()
            {
                connection.Dispose();
            }
    
            #endregion
        }
    }
