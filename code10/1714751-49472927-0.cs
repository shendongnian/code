    using System;
    using System.Data;
    using System.Data.SqlClient;
    namespace MyClassLibrary.DB
    {
        public class MyDB
        {
            public static System.Configuration.ConnectionStringSettings connString;
            public static SqlConnection conn;
            public static string sSQL;
            public int? InsertedID;
            public string Error;
            public SqlConnection Connection
            {
                get { return conn; }
            }
            private static void SetSQLConn()
            {
                if ((!(conn == null) && conn.State == ConnectionState.Open))
                {
                } else
                {
                    connString = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnString"];
                    conn = new SqlConnection();
                    conn.ConnectionString = connString.ConnectionString;
                    conn.Open();
                }
            }
            public DataTable QueryResults(string SQL) {
                SetSQLConn();
                sSQL = SQL;
                SqlCommand cmd = new SqlCommand(sSQL, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            //Note that all queryResult with parameter options require that the params be named @Param0, @Param1, etc.
            //SQLParam is a struct (defined below) defined like the following:
            //SQLParam[] paramslist = new SQLParam[1];
            //paramslist[0] = new SQLParam(SqlDbType.VarChar, "Mike"); //or enter string variable for the second param, since the first param is SqlDbType.VarChar
            //dt = QueryResultsWithParams("SELECT * FROM TestTable WHERE FirstName = @Param0", paramslist);  //dt is datatable - see Users/ResetPassword1 for an example of how to set this up.
            public DataTable QueryResultsWithParams(string SQL, params SQLParam[] paramlist)
                //This runs a select query with a parameter list (see restrictions above), and returns a filled data table with the query results.
            {
                SetSQLConn();
                sSQL = SQL;
            
                SqlCommand cmd = new SqlCommand(sSQL, conn);
                for (int i = 0; i < paramlist.Length; i++)
                {
                    cmd.Parameters.Add("@Param" + i, paramlist[i].Type);
                    cmd.Parameters["@Param" + i].Value = paramlist[i].Value;
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                da = null;
                cmd = null;
                return dt;
            }
            public void ActionQuery(string SQL)
            //This runs an action query (INSERT, DELETE, etc.) with parameters, and returns an error if there is one, or an empty string if it's successful.
            //see above for parameter restrictions.
            {
                Error = "";
                SetSQLConn();
                sSQL = SQL;
                bool bolIsInsert = (SQL.StartsWith("INSERT"));
                SqlCommand cmd = new SqlCommand(sSQL, conn);
                cmd.CommandType = CommandType.Text;
                try
                {
                    if (bolIsInsert)
                    {
                        cmd.Parameters.Add("@ID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                    }
                    cmd.ExecuteNonQuery();
                    if (bolIsInsert)
                    {
                        try
                        {
                            InsertedID = Convert.ToInt32(cmd.Parameters["@ID"].Value);
                        } catch { }
                    }
                }
                catch (SqlException e)
                {
                    Error = e.Message.ToString();
                }
            }
            public void ActionQueryWithParams(string SQL, params SQLParam[] paramlist)
                //This runs an action query (INSERT, DELETE, etc.) with parameters, and returns an error if there is one, or an empty string if it's successful.
                //see above for parameter restrictions.
            {
                Error = "";
                SetSQLConn();
                sSQL = SQL;
                bool bolIsInsert = (SQL.Contains("OUTPUT INSERTED."));
                SqlCommand cmd = new SqlCommand(sSQL, conn);
                for (int i = 0; i < paramlist.Length; i++)
                {
                    cmd.Parameters.Add("@Param" + i, paramlist[i].Type);
                    cmd.Parameters["@Param" + i].Value = paramlist[i].Value;
                }
                System.Diagnostics.Debug.WriteLine(cmd.Parameters.ToString());
                cmd.CommandType = CommandType.Text;
                try
                {
                    if (bolIsInsert)
                    {
                        cmd.Parameters.Add("@ID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                        InsertedID = (int)cmd.ExecuteScalar();
                    } else
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    Error = e.Message.ToString();
                }
            }
            public void Close()
            {
                conn.Close();
            }
        }
        public struct SQLParam
        {
            private SqlDbType m_Type;
            private dynamic m_Value;
            public SqlDbType Type
            {
                get { return m_Type; }
                set { m_Type = value; }
            }
            public dynamic Value
            {
                get { return m_Value; }
                set { m_Value = value; }
            }
            public SQLParam (SqlDbType ValType, dynamic val)
            {
                m_Value = val;
                m_Type = ValType;
            }
        }
    }
