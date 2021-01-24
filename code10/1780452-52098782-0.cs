    public static IEnumerable<T> Query<T>(
        this IDbConnection cnn,
        string sql,
        object param = null,
        IDbTransaction transaction = null,
        bool buffered = true,
        int? commandTimeout = null,
        CommandType? commandType = null
    )
