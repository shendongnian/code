    public static class Sqlite3
    {
        public static Action<sqlite3_context> ResultErrorTooBig =
            sqlite3_result_error_toobig;
        public static Func<T1, T2> AnotherMethod = 
            sqlite3_another_method;
    }
