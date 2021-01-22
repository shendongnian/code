/// <summary>
/// Helper class to work with data using ODP.NET.
/// </summary>
internal class OracleDataHelper
{
    #region Variables
    private static readonly string _connectionString;
    #endregion
    #region Constructors
    static OracleDataHelper()
    {
        _connectionString = ConfigurationManager.ConnectionStrings["..."].ConnectionString;
    }
    #endregion
    /// <summary>
    /// Executes a scalar expression.
    /// </summary>
    /// <param name="query">Query to execute.</param>
    /// <returns>Query result.</returns>
    public static object ExecuteScalar(string query)
    {
        object result;
        using (OracleConnection conn = new OracleConnection(ConnectionString))
        {
            conn.Open();
            OracleCommand command = new OracleCommand(query, conn);
            command.CommandType = CommandType.Text;
            result = command.ExecuteScalar();
            command.Dispose();
            conn.Close();
        }
        return result;
    }
    /// <summary>
    /// Executes a scalar expression.
    /// </summary>
    /// <param name="query">Query to execute.</param>
    /// <param name="parameters">A list of Oracle parameters.</param>
    /// <returns>Query result.</returns>
    public static object ExecuteScalar(string query, params object[] parameters)
    {
        object result;
        using (OracleConnection conn = new OracleConnection(ConnectionString))
        {
            conn.Open();
            OracleCommand command = new OracleCommand(query, conn);
            command.CommandType = CommandType.Text;
            command.Parameters.AddRange(ConvertParameters(parameters));
            result = command.ExecuteScalar();
            command.Dispose();
            conn.Close();
        }
        return result;
    }
    /// <summary>
    /// Executes a non-query expression.
    /// </summary>
    /// <param name="query">A query to execute.</param>
    /// <returns>Number of rows affected.</returns>
    public static int ExecuteNonQuery(string query)
    {
        return ExecuteNonQuery(query, new List<OracleParameter>());
    }
    /// <summary>
    /// Executes a non-query expression.
    /// </summary>
    /// <param name="query">A query to execute.</param>
    /// <param name="parameters">A list of Oracle parameters.</param>
    /// <returns>Number of rows affected.</returns>
    public static int ExecuteNonQuery(string query, List<OracleParameter> parameters)
    {
        int result = 0;
        using (OracleConnection conn = new OracleConnection(ConnectionString))
        {
            conn.Open();
            OracleCommand command = new OracleCommand(query, conn);
            command.CommandType = CommandType.Text;
            command.BindByName = true;
            command.Parameters.AddRange(ConvertParameters(parameters.ToArray()));
            result = command.ExecuteNonQuery();
            command.Dispose();
            conn.Close();
        }
        return result;
    }
    /// <summary>
    /// Executes a non-query expression.
    /// </summary>
    /// <param name="query">A query to execute.</param>
    /// <param name="parameters">A list of parameters.</param>
    /// <returns>Number of rows affected.</returns>
    public static int ExecuteNonQuery(
        string query,
        params object[] parameters)
    {
        int result = 0;
        using (OracleConnection conn = new OracleConnection(ConnectionString))
        {
            conn.Open();
            OracleCommand command = new OracleCommand(query, conn);
            command.BindByName = true;
            command.CommandType = CommandType.Text;
            command.Parameters.AddRange(ConvertParameters(parameters));
            result = command.ExecuteNonQuery();
            command.Dispose();
            conn.Close();
        }
        return result;
    }
    /// <summary>
    /// Executes data reader without output parameters.
    /// Note: the connection should be closed outside this method as soon as possible.
    /// </summary>
    /// <param name="conn">Oracle connection object.</param>
    /// <param name="commandText">Command query to execute.</param>
    /// <returns>DataReader object.</returns>
    public static OracleDataReader ExecuteReader(
        OracleConnection conn,
        string commandText
        )
    {
        OracleCommand command = new OracleCommand(commandText, conn);
        return command.ExecuteReader();
    }
    /// <summary>
    /// Executes data reader. Output parameters is supported.
    /// Note: the connection should be closed outside this method as soon as possible.
    /// </summary>
    /// <param name="conn">Oracle connection object.</param>
    /// <param name="spName">Stored procedure name to execute.</param>
    /// <param name="parameters">Stored procedure parametrs.</param>
    /// <returns>IDataReader object.</returns>
    public static IDataReader ExecuteReader(OracleConnection conn, string spName, out List<OracleParameter> outParameters, params object[] parameters)
    {
        throw new NotImplementedException();
    }
    /// <summary>
    /// Executes a stored procedure with output parameters.
    /// </summary>
    /// <param name="spName">Procedure name to execute.</param>
    /// <param name="outputParameters">Procedure's output parameters.</param>
    /// <param name="parameters">Procedure parameters.</param>
    /// <returns>Number of rows affected.</returns>
    public static int ExecuteProcedure(
        string spName,
        out OutputParameters outputParameters,
        params object[] parameters)
    {
        int result = 0;
        using (OracleConnection conn = new OracleConnection(ConnectionString))
        {
            conn.Open();
            OracleCommand command = new OracleCommand(spName, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddRange(ConvertParameters(parameters));
            result = command.ExecuteNonQuery();
            outputParameters = GetOutputParameters(command.Parameters);
            command.Dispose();
            conn.Close();
        }
        return result;
    }
    /// <summary>
    /// Executes a stored procedure without output parameters.
    /// </summary>
    /// <param name="spName">Procedure name to execute.</param>
    /// <param name="parameters">Procedure parameters.</param>
    /// <returns>Number of rows affected.</returns>
    public static int ExecuteProcedure(
        string spName,
        params object[] parameters)
    {
        int result = 0;
        using (OracleConnection conn = new OracleConnection(ConnectionString))
        {
            conn.Open();
            OracleCommand command = new OracleCommand(spName, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddRange(ConvertParameters(parameters));
            result = command.ExecuteNonQuery();
            command.Dispose();
            conn.Close();
        }
        return result;
    }
    /// <summary>
    /// Executes a stored procedure with output parameters.
    /// </summary>
    /// <param name="conn">Oracle connection object.</param>
    /// <param name="spName">Procedure name to execute.</param>
    /// <param name="outputParameters">Procedure's output parameters.</param>
    /// <param name="parameters">Procedure parameters.</param>
    /// <returns>OracleDataReader object.</returns>
    public static OracleDataReader ExecuteProcedure(
        OracleConnection conn,
        string spName,
        out OutputParameters outputParameters,
        params object[] parameters
        )
    {
        OracleCommand command = new OracleCommand(spName, conn);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddRange(ConvertParameters(parameters));
        OracleDataReader reader = command.ExecuteReader();
        outputParameters = GetOutputParameters(command.Parameters);
        command.Dispose();
        return reader;
    }
    /// <summary>
    /// Executes a stored procedure without output parameters.
    /// </summary>
    /// <param name="conn">Oracle connection object.</param>
    /// <param name="spName">Procedure name to execute.</param>
    /// <param name="parameters">Procedure parameters.</param>
    /// <returns>OracleDataReader object.</returns>
    public static OracleDataReader ExecuteProcedure(
        OracleConnection conn,
        string spName,
        params object[] parameters
        )
    {
        OracleCommand command = new OracleCommand(spName, conn);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddRange(ConvertParameters(parameters));
        OracleDataReader reader = command.ExecuteReader();
        command.Dispose();
        return reader;
    }
    private static OracleParameter[] ConvertParameters(object[] parameters)
    {
        if (parameters == null)
            parameters = new object[] { };
        int parametersCount = parameters.Length;
        OracleParameter[] parametersArray = new OracleParameter[parametersCount];
        for (int i = 0; i < parametersCount; i++)
        {
            object parameter = parameters[i];
            OracleParameter oracleParameter;
            if (parameter is OracleParameter)
            {
                oracleParameter = (OracleParameter)parameter;
                if (null == oracleParameter.Value)
                {
                    oracleParameter.Value = DBNull.Value;
                }
            }
            else
            {
                oracleParameter = new OracleParameter();
                oracleParameter.Value = parameter == null ?
                    DBNull.Value :
                    parameter;
            }
            // adding udt mapping for the parameter
            if (oracleParameter.Value != null && oracleParameter.Value is IOracleCustomTypeFactory)
            {
                MemberInfo info = oracleParameter.Value.GetType();
                OracleCustomTypeMappingAttribute[] attributes = info.GetCustomAttributes(typeof(OracleCustomTypeMappingAttribute), false) as OracleCustomTypeMappingAttribute[];
                if (null != attributes && attributes.Length > 0)
                {
                    oracleParameter.UdtTypeName = attributes[0].UdtTypeName;
                }
            }
            parametersArray[i] = oracleParameter;
        }
        return parametersArray;
    }
    private static OutputParameters GetOutputParameters(OracleParameterCollection parameters)
    {
        OutputParameters outputParameters = new OutputParameters();
        foreach (OracleParameter parameter in parameters)
        {
            if (parameter.Direction == ParameterDirection.Output)
                outputParameters.Add(parameter);
        }
        return outputParameters;
    }
    internal static string ConnectionString
    {
        get { return _connectionString; }
    }
}
