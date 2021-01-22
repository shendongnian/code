    string sql = "insert into MyTbl(Tdate,Ttime) values (:date, :time)";
    using (OracleCommand cmd = new OracleCommand(sql, connection))
    {
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("date", OracleType.DateTime).Value = date;
        cmd.Parameters.Add("time", OracleType.IntervalDayToSecond).Value = time;
        cmd.ExecuteNonQuery();
    }
