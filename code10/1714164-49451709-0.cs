        public static string CountTblColumByValue(string columNameWhereClause,string whereConditionValue)
        {
            var cs = ConfigurationManager.ConnectionStrings["BD_CompanyConnectionString"].ConnectionString;
            using (var con = new SqlConnection(cs))
            {
                var sqlQuary ="Select Count(SomePrimaryKeyColumn) from tblAttendance1 where {columnNameWhereClause } = {(whereConditionValue==null ? "= is null" : "= '" + whereConditionValue + "')}"; //use command parameters for avoiding SQLInjection
                using(var cmd = new SqlCommand(sqlQuary, con))
                {
                    con.Open();
                    object count=cmd.ExecuteScalar();
                    return count.ToString();
                }
            }
        }
    }
