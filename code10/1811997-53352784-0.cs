                SqlParameter fromDate = new SqlParameter();
                fromDate.ParameterName = "@FromDate";
                fromDate.SqlDbType = SqlDbType.Date;
                fromDate.Direction = ParameterDirection.Input;
                fromDate.Value = FromDateTxt.Value;
    
                SqlParameter toDate = new SqlParameter();
                toDate.ParameterName = "@ToDate";
                toDate.SqlDbType = SqlDbType.Date;
                toDate.Direction = ParameterDirection.Input;
                toDate.Value = ToDateTxt.Value;
    
                OleDbCommand pending = new OleDbCommand("SELECT * FROM businesses WHERE business_active = 0 AND date_of_application BETWEEN @FromDate AND @ToDate", cn.con);
                OleDbDataReader dr_pending = pending.ExecuteReader();
