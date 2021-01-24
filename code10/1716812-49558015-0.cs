    cmd.CommandText = @"UPDATE Results SET Finish = @finished, Place = @place, FinishTime = @time, Winnings = @winnings Where ResultsId = @resultId ";
    cmd.Parameters.Add(new SqlParameter("@finished", System.Data.SqlDbType.Bit).Value = rdoDidFinish.Checked);
    cmd.Parameters.Add(new SqlParameter("@place", System.Data.SqlDbType.VarChar).Value = txtPlace.Text);
    cmd.Parameters.Add(new SqlParameter("@time", System.Data.SqlDbType.VarChar).Value = txtTime.Text);
    cmd.Parameters.Add(new SqlParameter("@winnings", System.Data.SqlDbType.VarChar).Value = txtWinnings.Text);
    cmd.Parameters.Add(new SqlParameter("@resultId", System.Data.SqlDbType.Int).Value = resultId);
