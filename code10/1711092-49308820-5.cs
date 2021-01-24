    public T ExecuteScalar<T>(SqlCommand command)
    {
        using (SqlConnection connection = new SqlConnection(_connStr))
        {
            command.Connection = connection;
            //SqlDataAdapter da = new SqlDataAdapter(command); //not needed...
            command.Connection.Open();
            var result = command.ExecuteScalar();
            //rather than just returning result with an implicit cast, use Max's trick from here: https://stackoverflow.com/a/2976427/361842
            if (Convert.IsDbNull(result))
                return default(T); //handle the scenario where the returned value is null, but the type is not nullable (or remove this to have such scenarios throw an exception)
            if (result is T)
                return (T)result;
            else
                (T)Convert.ChangeType(result, typeof(T));
        }
    }
