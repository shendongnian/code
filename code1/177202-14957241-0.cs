    private int InternalExecuteNonQuery(DbAsyncResult result, string methodName, bool sendToPipe)
    {
        if (!this._activeConnection.IsContextConnection)
        {
            if (this.BatchRPCMode || CommandType.Text != this.CommandType || this.GetParameterCount(this._parameters) != 0)
            {
                Bid.Trace("<sc.SqlCommand.ExecuteNonQuery|INFO> %d#, Command executed as RPC.\n", this.ObjectID);
                SqlDataReader sqlDataReader = this.RunExecuteReader(CommandBehavior.Default, RunBehavior.UntilDone, false, methodName, result);
                if (sqlDataReader == null)
                {
                    goto IL_E5;
                }
                sqlDataReader.Close();
                goto IL_E5;
            }
        IL_B5:
            this.RunExecuteNonQueryTds(methodName, flag);
        }
        else
        {
            this.RunExecuteNonQuerySmi(sendToPipe);
        }
    IL_E5:
        return this._rowsAffected;
    }
