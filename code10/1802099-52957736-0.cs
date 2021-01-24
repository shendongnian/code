    cmdNumWins.Parameters.Add(new NpgsqlParameter("@selid", NpgsqlDbType.Integer));
    cmdNumPlcs.Parameters.Add(new NpgsqlParameter("@selid", NpgsqlDbType.Integer));
    cmdNumLosses.Parameters.Add(new NpgsqlParameter("@selid", NpgsqlDbType.Integer));
    List<int> idList = new List<int>();
    using (NpgsqlDataReader drGetSelectionIds = cmdGetSelectionIds.ExecuteReader())
    {
        while (drGetSelectionIds.Read())
            idList.Add(drGetSelectionIds.GetInt32(0));
        drGetSelectionIds.Close();
    }
    foreach (int selid in idList)
    {
        cmdNumWins.Parameters[0].Value = selid;
        cmdNumPlcs.Parameters[0].Value = selid;
        cmdNumLosses.Parameters[0].Value = selid;
        numWins = Convert.ToInt32(cmdNumWins.ExecuteScalar());
        numPlcs = Convert.ToInt32(cmdNumPlcs.ExecuteScalar());
        numLosses = Convert.ToInt32(cmdNumLosses.ExecuteScalar());
        Console.Write("selid : {0} \t num W {1} \t num P {2} num L {3} \t points {4}\n", selid, 
            numWins, numPlcs, numLosses, (3.0 * numWins + numPlcs) / (numWins + numLosses));
    }
