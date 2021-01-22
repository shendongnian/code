    /// <summary>
    /// This will add an array of parameters to a SqlCommand. This is used for an IN statement.
    /// Use the returned value for the IN part of your SQL call. (i.e. SELECT * FROM table WHERE field IN (returnValue))
    /// </summary>
    /// <param name="sqlCommand">The SqlCommand object to add parameters to.</param>
    /// <param name="array">The array of strings that need to be added as parameters.</param>
    /// <param name="paramName">What the parameter should be named.</param>
    protected string AddArrayParameters(SqlCommand sqlCommand, string[] array, string paramName)
    {
    	/* An array cannot be simply added as a parameter to a SqlCommand so we need to loop through things and add it manually. 
    	 * Each item in the array will end up being it's own SqlParameter so the return value for this must be used as part of the
    	 * IN statement in the CommandText.
    	 */
    	var parameters = new string[array.Length];
    	for (int i = 0; i < array.Length; i++)
    	{
    		parameters[i] = string.Format("@{0}{1}", paramName, i);
    		sqlCommand.Parameters.AddWithValue(parameters[i], array[i]);
    	}
    
    	return string.Join(", ", parameters);
    }
