    Using da As New SqlDataAdapter
          da.UpdateCommand = conn.CreateCommand
          da.UpdateCommand.CommandTimeout = 300
    
          da.AcceptChangesDuringUpdate = False
          da.ContinueUpdateOnError = False
          da.UpdateBatchSize = 1000 ‘Expirement for best preformance
          da.UpdateCommand.UpdatedRowSource = UpdateRowSource.None 'Needed if UpdateBatchSize > 1
          sql = "UPDATE YourTable"
          sql += " SET YourField = @YourField"
          sql += " WHERE ID = @ID"
          da.UpdateCommand.CommandText = sql
          da.UpdateCommand.UpdatedRowSource = UpdateRowSource.None
          da.UpdateCommand.Parameters.Clear()
          da.UpdateCommand.Parameters.Add("@YourField", SqlDbType.SmallDateTime).SourceColumn = "YourField"
          da.UpdateCommand.Parameters.Add("@ID", SqlDbType.SmallDateTime).SourceColumn = "ID"
    
          da.Update(ds.Tables("YourTable”)
    End Using
