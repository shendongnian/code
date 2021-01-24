    public void insertActiveMonitorsForScoreboard(SqlConnection dbConn, SqlTransaction dbTrans, int scoreboardId,
     ObservableCollection<AvailableMonitorBo> availableMonitorsForAddOC) {         
       foreach (AvailableMonitorBo bo in availableMonitorsForAddOC) {
           if (bo.IsActive) {
               using (SqlCommand dbCommand = new SqlCommand(CreateAndDisplaySQLStrings.INSERT_SCOREBOARD_MONITORS, dbConn)) {
                   dbCommand.Transaction = dbTrans;
                   dbCommand.Parameters.Add("scoreboardId", SqlDbType.Int).Value = scoreboardId;
                   dbCommand.Parameters.Add("availableMonitorId", SqlDbType.Int).Value = bo.AvailableMonitorId;
                   dbCommand.ExecuteNonQuery();
              }                   
           }               
        }
    }
