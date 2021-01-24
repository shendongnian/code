    string sqlStatement = "UPDATE Results SET Finish = @Finish, Place = @Place, FinishTime = @FinishTime, Winnings = @Winnings WHERE ResultsId = @ResultID";
    using (SqlConnection cnn = new SqlConnection(Properties.Settings.Default.cnnString)) {
        SqlCommand cmd = cnn.CreateCommand(sqlStatement, cnn);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.AddWithValue("@Finish", (rdoDidFinish.Checked ? 1 : 0));     // I think this belongs here.
        cmd.Parameters.AddWithValue("@Place", txtPlace.Text);
        cmd.Parameters.AddWithValue("@FinishTime", txtTime.Text);
        cmd.Parameters.AddWithValue("@Winnings", txtWinnings.Text);
        // cmd.Parameters.AddWithValue("@ResultID", );                                ? What belongs here ?
        cnn.Open();
        cmd.ExecuteNonQuery();
        cnn.Close();
}
