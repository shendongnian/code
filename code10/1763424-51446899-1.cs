    void GetMeetings(IEnumerable<int> roomIdentifiers)
    {
        // A simplified version of your query to show just the relevant part:
        const string sqlText = @"
            select
                M.*
            from
                Meeting M
            where 
                exists (select 1 from @RoomIds R where M.RoomId = R.Identifier);";
                
        using (var sqlCon = new SqlConnection("<your connection string here>"))
        {
        	sqlCon.Open();
        	using (var sqlCmd = new SqlCommand(sqlText, sqlCon))
        	{
                sqlCmd.Parameters.Add(CreateIdentifierTableParameter("RoomIds", roomIdentifiers));
                
                // Execute sqlCmd here in whatever way is appropriate.
        	}
        }
    }
