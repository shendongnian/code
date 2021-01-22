    #region Add by Name/Value.
	/// <summary>
	/// Adds an input parameter with a name and value.  Automatically handles conversion of null object values to DBNull.Value.
	/// </summary>
	/// <param name="parameters">SqlParameterCollection from an SqlCommand instance.</param>
	/// <param name="name">The name of the parameter to add.</param>
	/// <param name="value">The value of the parameter to add.</param>
	private static void AddParameter( SqlParameterCollection parameters, string name, object value )
	{
		parameters.Add( new SqlParameter( name, value ?? DBNull.Value ) );
	}
	/// <summary>
	/// Adds a parameter with a name and value.  You specify the input/output direction.  Automatically handles conversion of null object values to DBNull.Value.
	/// </summary>
	/// <param name="parameters">SqlParameterCollection from an SqlCommand instance.</param>
	/// <param name="name">The name of the parameter to add.</param>
	/// <param name="value">The value of the parameter to add.  If null, this is automatically converted to DBNull.Value.</param>
	/// <param name="direction">The ParameterDirection of the parameter to add (input, output, input/output, or return value).</param>
	private static void AddParameter( SqlParameterCollection parameters, string name, object value, ParameterDirection direction )
	{
		SqlParameter parameter = new SqlParameter( name, value ?? DBNull.Value );
		parameter.Direction = direction;
		parameters.Add( parameter );
	}
	#endregion
	#region Add by Name, Type, and Value.
	/// <summary>
	/// Adds an input parameter with a name, type, and value.  Automatically handles conversion of null object values to DBNull.Value.
	/// </summary>
	/// <param name="parameters">SqlParameterCollection from an SqlCommand instance.</param>
	/// <param name="name">The name of the parameter to add.</param>
	/// <param name="type">Specifies the SqlDbType of the parameter.</param>
	/// <param name="value">The value of the parameter to add.  If null, this is automatically converted to DBNull.Value.</param>
	private static void AddParameter( SqlParameterCollection parameters, string name, SqlDbType type, object value )
	{
		AddParameter( parameters, name, type, 0, value ?? DBNull.Value, ParameterDirection.Input );
	}
	/// <summary>
	/// Adds a parameter with a name, type, and value.  You specify the input/output direction.  Automatically handles conversion of null object values to DBNull.Value.
	/// </summary>
	/// <param name="parameters">SqlParameterCollection from an SqlCommand instance.</param>
	/// <param name="name">The name of the parameter to add.</param>
	/// <param name="type">Specifies the SqlDbType of the parameter.</param>
	/// <param name="value">The value of the parameter to add.  If null, this is automatically converted to DBNull.Value.</param>
	/// <param name="direction">The ParameterDirection of the parameter to add (input, output, input/output, or return value).</param>
	private static void AddParameter( SqlParameterCollection parameters, string name, SqlDbType type, object value, ParameterDirection direction )
	{
		AddParameter( parameters, name, type, 0, value ?? DBNull.Value, direction );
	}
	#endregion
	#region Add by Name, Type, Size, and Value.
	/// <summary>
	/// Adds an input parameter with a name, type, size, and value.  Automatically handles conversion of null object values to DBNull.Value.
	/// </summary>
	/// <param name="parameters">SqlParameterCollection from an SqlCommand instance.</param>
	/// <param name="name">The name of the parameter to add.</param>
	/// <param name="type">Specifies the SqlDbType of the parameter.</param>
	/// <param name="size">Specifies the size of the parameter for parameter types of variable size.  Set to zero to use the default size.</param>
	/// <param name="value">The value of the parameter to add.  If null, this is automatically converted to DBNull.Value.</param>
	private static void AddParameter( SqlParameterCollection parameters, string name, SqlDbType type, int size, object value )
	{
		AddParameter( parameters, name, type, size, value ?? DBNull.Value, ParameterDirection.Input );
	}
	/// <summary>
	/// Adds a parameter with a name, type, size, and value.  You specify the input/output direction.  Automatically handles conversion of null object values to DBNull.Value.
	/// </summary>
	/// <param name="parameters">SqlParameterCollection from an SqlCommand instance.</param>
	/// <param name="name">The name of the parameter to add.</param>
	/// <param name="type">Specifies the SqlDbType of the parameter.</param>
	/// <param name="size">Specifies the size of the parameter for parameter types of variable size.  Set to zero to use the default size.</param>
	/// <param name="value">The value of the parameter to add.  If null, this is automatically converted to DBNull.Value.</param>
	/// <param name="direction">The ParameterDirection of the parameter to add (input, output, input/output, or return value).</param>
	private static void AddParameter( SqlParameterCollection parameters, string name, SqlDbType type, int size, object value, ParameterDirection direction )
	{
		SqlParameter parameter;
		if (size < 1)
			parameter = new SqlParameter( name, type );
		else
			parameter = new SqlParameter( name, type, size );
		parameter.Value = value ?? DBNull.Value;
		parameter.Direction = direction;
		parameters.Add( parameter );
	}
	#endregion
