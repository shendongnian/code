    using (SqlCommand cmd = new SqlCommand(select_for_IsDatamartSynced, conn))
    {
        IsDatamartSynced = cmd.ExecuteScalar();
        log.Info($"in using {IsDatamartSynced}");
    }
