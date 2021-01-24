    using(var sqlCon = new SqlConnetion())
    {
        using(var sqlCommand = sqlCon.CreateCommand())
        {
            sqlCommand.CommandText = "SELECT COUNT(EMP_CODE) FROM Attendance where Month = @curMonth and EMP_CODE= @empCode";
            command.Parameters.Add("@curMonth", SqlDbType.Int).Value = curMonth;
            command.Parameters.Add("@empCode", SqlDbType.Int).Value = 2222;
            var count = (int)sqlCommand.ExecetueScalar();
            txtPresentDay.Text = Convert.ToString(count);
        }
    }
