    StringBuilder sql = new StringBuilder(
         "SELECT * FROM [SOME_TABLE] WHERE 1=1");
    if(!string.IsNullOrEmpty(name)) {
        sql.Append(" AND [Name]=@name");
    }
    if(activeOnly) {
        sql.Append(" AND IsActive = 1");
    }
    if(minDate != DateTime.MinValue) {
        sql.Append(" AND [Date]>=@minDate");
    }
    if(maxDate != DateTime.MinValue) {
        sql.Append(" AND [Date]<=@maxDate");
    }
    // create connection, create command, add parameters, use ExecuteReader etc
