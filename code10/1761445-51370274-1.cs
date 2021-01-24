    private static void LogToDB(string exceptionType, string exceptionMessage)
    {
       ....
       List<SqlParameter> sp = new List<SqlParameter>() {
                new SqlParameter("@exceptionType", exceptionType) { },
                new SqlParameter("@exceptionMessage", exceptionMessage) { }
            };
       ...
     }
