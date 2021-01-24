    public void insertActiveMonitorsForScoreboard(SqlConnection dbConn, SqlTransaction dbTrans, int scoreboardId,
     ObservableCollection<AvailableMonitorBo> availableMonitorsForAddOC) {         
         using (SqlCommand dbCommand = new SqlCommand(CreateAndDisplaySQLStrings.INSERT_SCOREBOARD_MONITORS, dbConn)) {
               dbCommand.Transaction = dbTrans;
               dbCommand.Parameters.Add("scoreboardId", SqlDbType.Int);
               dbCommand.Parameters.Add("availableMonitorId", SqlDbType.Int);
               foreach (AvailableMonitorBo bo in availableMonitorsForAddOC) {
                   if (bo.IsActive) {
                       dbCommand.Parameters["scoreboardId"].Value = scoreboardId;
                       dbCommand.Parameters["availableMonitorId"].Value = bo.AvailableMonitorId;
                       dbCommand.ExecuteNonQuery();
                  }                   
            }               
        }
    }
