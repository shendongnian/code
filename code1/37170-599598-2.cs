    //Courtesy of http://www.codoxide.com/post/My-Favorite-Database-Wrapper-for-C.aspx
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data;
    using System.Data.Common;
    
    namespace GenApp.Core.Providers.nsDb
    {
        //comm -- / <summary>
        //comm -- / Abstract base class for encapsulating provider independant database interactin logic. 
        //comm -- / </summary>
        //comm -- / <typeparam name="CONNECTION_TYPE"><see cref="DbConnection"/> derived Connection type.</typeparam>
        //comm -- / <typeparam name="COMMAND_TYPE"><see cref="DbCommand"/> derived Command type.</typeparam>
        //comm -- / <typeparam name="ADAPTER_TYPE"><see cref="DbDataAdapater"/> derived Data Adapter type.</typeparam>
        public abstract 
            class AbstractDatabase<CONNECTION_TYPE, COMMAND_TYPE, ADAPTER_TYPE> : IDisposable
            where CONNECTION_TYPE : DbConnection, new()
            where COMMAND_TYPE : DbCommand
            where ADAPTER_TYPE : DbDataAdapter, new()
        {
            #region : Connection :
    
            //comm -- / <summary>Gets the Connection object associated with the current instance.</summary>
            public DbConnection Connection
            {
                get
                {
                    if (internal_currentConnection == null)
                    {
                        internal_currentConnection = new CONNECTION_TYPE();
    										// - Enable to measure the connection timeGenApp.Core.Providers.nsDbMeta.DbDebugger.WriteIf ( ref userObj , "GetConnectionString START" );
                        internal_currentConnection.ConnectionString = GetConnectionString();
    										// - Enable to measure the connection timeGenApp.Core.Providers.nsDbMeta.DbDebugger.WriteIf ( ref userObj , "GetConnectionString END" );
                    }
                    return internal_currentConnection;
                }
            }
            private DbConnection internal_currentConnection;
    
            //comm -- / <summary>When overridden in derived classes returns the connection string for the database.</summary>
            //comm -- / <returns>The connection string for the database.</returns>
            protected abstract string GetConnectionString();
    
            #endregion
    
            #region : Commands :
    
            //comm -- / <summary>Gets a DbCommand object with the specified <see cref="DbCommand.CommandText"/>.</summary>
            //comm -- / <param name="sqlString">The SQL string.</param>
            //comm -- / <returns>A DbCommand object with the specified <see cref="DbCommand.CommandText"/>.</returns>
            public DbCommand GetSqlStringCommand(string sqlString)
            {
                if (this.Connection.State != ConnectionState.Open)
                    this.Connection.Open();
    
                DbCommand cmd  = this.Connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sqlString;
                return cmd;
            }
    
            //comm -- / <summary>Gets a DbCommand object with the specified <see cref="DbCommand.CommandText"/>.</summary>
            //comm -- / <param name="sqlStringFormat">The SQL string format.</param>
            //comm -- / <param name="args">The format arguments.</param>
            //comm -- / <returns>A DbCommand object with the specified <see cref="DbCommand.CommandText"/>.</returns>
            public DbCommand GetSqlStringCommand(string sqlStringFormat, params object[] args)
            {
                return GetSqlStringCommand(string.Format(sqlStringFormat, args));
            }
    
            //comm -- / <summary>Gets a DbCommand object for the specified Stored Procedure.</summary>
            //comm -- / <param name="storedProcName">The name of the stored procedure.</param>
            //comm -- / <returns>A DbCommand object for the specified Stored Procedure.</returns>
            public DbCommand GetStoredProcedureCommand(string storedProcName)
            {
                if (this.Connection.State != ConnectionState.Open)
                    this.Connection.Open();
    
                DbCommand cmd    = this.Connection.CreateCommand();
                cmd.CommandType   = CommandType.StoredProcedure;
                cmd.CommandText   = storedProcName;
                return cmd;
            }
    
            #region : Parameters :
    
            //comm -- / <summary>Adds an input parameter to the given <see cref="DbCommand"/>.</summary>
            //comm -- / <param name="cmd">The command object the parameter should be added to.</param>
            //comm -- / <param name="paramName">The identifier of the parameter.</param>
            //comm -- / <param name="paramType">The type of the parameter.</param>
            //comm -- / <param name="value">The value of the parameter.</param>
            //comm -- / <returns>The <see cref="DbParameter"/> that was created.</returns>
            public DbParameter AddInParam(DbCommand cmd, string paramName, DbType paramType, object value)
            {
                DbParameter param       = cmd.CreateParameter();
                param.DbType            = paramType;
                param.ParameterName     = paramName;
                param.Value             = value;
                param.Direction         = ParameterDirection.Input;
                cmd.Parameters.Add( param );
                return param;
    				} //eof method AddInParam
    
            //comm -- / <summary>Adds an input parameter to the given <see cref="DbCommand"/>.</summary>
            //comm -- / <param name="cmd">The command object the parameter should be added to.</param>
            //comm -- / <param name="paramName">The identifier of the parameter.</param>
            //comm -- / <param name="paramType">The type of the parameter.</param>
            //comm -- / <param name="size">The maximum size in bytes, of the data table column to be affected.</param>
            //comm -- / <param name="value">The value of the parameter.</param>
            //comm -- / <returns>The <see cref="DbParameter"/> that was created.</returns>
            public DbParameter AddInParam(DbCommand cmd, string paramName, DbType paramType, int size, object value)
            {
                DbParameter param       = cmd.CreateParameter();
                param.DbType            = paramType;
                param.ParameterName     = paramName;
                param.Size              = size;
                param.Value             = value;
                param.Direction         = ParameterDirection.Input;
                //debugGenApp.Core.Providers.nsDbMeta.DbDebugger.WriteIf ( ref userObj , "Adding IN param " + value.ToString ( ) );
                cmd.Parameters.Add(param);
                return param;
            }
    
            public DbParameter AddInOutParam ( DbCommand cmd, string paramName, DbType paramType, int size, object value )
                {
                DbParameter param = cmd.CreateParameter ( );
                param.DbType = paramType;
                param.ParameterName = paramName;
                param.Size = size;
                param.Value = value;
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add ( param );
                //debug if needed here 
                return param;
                }
    
    
            public DbParameter AddInOutParam ( DbCommand cmd, string paramName, DbType paramType, object value )
                {
                DbParameter param = cmd.CreateParameter ( );
                param.DbType = paramType;
                param.ParameterName = paramName;
                param.Value = value;
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add ( param );
                return param;
                }
    
            #endregion
    
            #region : Executes :
    
            //comm -- / <summary>Executes the specified command against the current connection.</summary>
            //comm -- / <param name="cmd">The command to be executed.</param>
            //comm -- / <returns>Result returned by the database engine.</returns>
            public int ExecuteNonQuery(DbCommand cmd)
            {
                if (this.Connection.State != ConnectionState.Open)
                    this.Connection.Open();
    
                return cmd.ExecuteNonQuery();
            }
    
            //comm -- / <summary>Executes the specified command against the current connection.</summary>
            //comm -- / <param name="cmd">The command to be executed.</param>
            //comm -- / <param name="txn">The database transaction inside which the command should be executed.</param>
            //comm -- / <returns>Result returned by the database engine.</returns>
            public int ExecuteNonQuery(DbCommand cmd, DbTransaction txn)
            {
                if (this.Connection.State != ConnectionState.Open)
                    this.Connection.Open();
    
                cmd.Transaction = txn;
                return cmd.ExecuteNonQuery();
            }
    
            //comm -- / <summary>Executes the specified command against the current connection.</summary>
            //comm -- / <param name="cmd">The command to be executed.</param>
            //comm -- / <returns>Result returned by the database engine.</returns>
            public DbDataReader ExecuteReader(DbCommand cmd)
            {
                if (this.Connection.State != ConnectionState.Open)
                    this.Connection.Open();
    
                return cmd.ExecuteReader();
            }
    
            //comm -- / <summary>Executes the specified command against the current connection.</summary>
            //comm -- / <param name="cmd">The command to be executed.</param>
            //comm -- / <param name="behavior">One of the <see cref="System.Data.CommandBehavior"/> values.</param>
            //comm -- / <returns>Result returned by the database engine.</returns>
            public DbDataReader ExecuteReader(DbCommand cmd ,  CommandBehavior behavior )
            {
                if (this.Connection.State != ConnectionState.Open)
                    this.Connection.Open();
    
                return cmd.ExecuteReader(behavior);
            }
    
            //comm -- / <summary>Executes the specified command against the current connection.</summary>
            //comm -- / <param name="cmd">The command to be executed.</param>
            //comm -- / <returns>Result returned by the database engine.</returns>
            public T ExecuteScalar<T>(DbCommand cmd, T defaultValue)
            {
                if (this.Connection.State != ConnectionState.Open)
                    this.Connection.Open();
    
                object retVal = cmd.ExecuteScalar();
                if (null == retVal || DBNull.Value == retVal)
                    return defaultValue;
                else
                    return (T)retVal;
            }
    
            //comm -- / <summary>Executes the specified command against the current connection.</summary>
            //comm -- / <param name="cmd">The command to be executed.</param>
            //comm -- / <returns>Result returned by the database engine.</returns>
            public DataSet ExecuteDataSet(DbCommand cmd)
            {
                ADAPTER_TYPE adapter  = new ADAPTER_TYPE();
                adapter.SelectCommand = (COMMAND_TYPE)cmd;
    
                
                DataSet retVal = new DataSet();
                adapter.Fill(retVal);
                return retVal;
            }
    
            ////comm -- / <summary>Executes the specified command against the current connection.</summary>
            ////comm -- / <param name="cmd">The command to be executed.</param>
            ////comm -- / <returns>Result returned by the database engine.</returns>
            //public DataSet ExecuteDataSet(DbCommand cmd )
            //{
            //  ADAPTER_TYPE adapter = new ADAPTER_TYPE();
            //  adapter.SelectCommand = (COMMAND_TYPE)cmd;
            //  //cmd.CommandTimeout = 3600
            //  DataSet retVal = new DataSet();
            //  adapter.Fill(retVal);
            //  return retVal;
            //}
    
            #endregion
    
            #endregion
    
            //comm -- / <summary>Begins a transaction.</summary>
            //comm -- / <returns>Created transaction.</returns>
            public DbTransaction BeginTransaction()
            {
                if (this.Connection.State != ConnectionState.Open)
                    this.Connection.Open();
                return Connection.BeginTransaction();
            }
    
            #region : Construction / Destruction :
    
            //comm -- / <summary>Disposes the resources associated with the current database connection.</summary>
            ~AbstractDatabase()
            {
                Dispose();
            }
    
            #region IDisposable Members
    
            //comm -- / <summary>Disposes the resources associated with the current database connection.</summary>
            public void Dispose()
            {
                if (null != internal_currentConnection)
                {
                    internal_currentConnection.Dispose();
                    internal_currentConnection = null;
                }
            }
    
            #endregion
    
            #endregion
    
        } //eof public abstract class AbstractDatabase
    } //eof namespace Providers.nsDb 
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data.SqlClient;
    
    
    namespace GenApp.Core.Providers.nsDb
    {
        public class Database : AbstractDatabase<SqlConnection, SqlCommand, SqlDataAdapter>
        {
    
    				
    
    
    					private string _ConnectionString;
    					public string ConnectionString
    					{
    						get { return _ConnectionString; }
    						set { _ConnectionString = value; }
    					} //eof property FieldName 
    
    					public Database ( string connectionStr )
    					{
                //debugGenApp.Core.Providers.nsDbMeta.DbDebugger.WriteIf(ref userObj , " CHECK --- nsDb.Database using the following connection string " + connectionStr);
    						this.ConnectionString = connectionStr; 
    					} //eof constructor 
    
    
    			protected override string GetConnectionString ( )
    			{
    
    				//GenApp.Core.Providers.nsDbMeta.DbDebugger.WriteIf ( ref userObj , "In GetConnectionString the ConnectionString is " + this.ConnectionString );
    				//GenApp.Core.Providers.nsDbMeta.DbDebugger.WriteIf ( ref userObj , "The comming fromURL IS " + commingFromURL );
    				return this._ConnectionString;
    			} //eof protected override string GetConnectionString()
    
        } //eof class 
    } //eof namespace Providers.nsDb
