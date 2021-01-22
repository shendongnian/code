    IEnumerable<MyFancyData> ResultSet {
        get {
            using(DbConnection conn = ...) 
            using(DbCommand cmd = ...) {
                conn.Open();
                
                using(DbDataReader reader = cmd.ExecuteReader()) {
                    while(reader.Read()) {
                        yield return new MyFancyData(reader[0], reader[42] ...);
                    }
                }
            }
        }
    }
