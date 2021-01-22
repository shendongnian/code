    [WebMethod]
    public MiniEvent[] getAdminEvents(Int32[] buildingIDs, DateTime startDate)
    {
        // Gets a list with numbers from 0 to the max index in buildingIDs,
        // then transforms it into a list of strings using those numbers.
        String idParamString = String.Join(", ", (Enumerable.Range(0, buildingIDs.Length).Select(i => "@item" + i)).ToArray());
        command.CommandText = @"SELECT id,
                            startDateTime, endDateTime From
                            tb_bookings WHERE buildingID IN
                            (" + idParamString + @") AND startDateTime <=
                            @fromDate";
        // Reproduce the same parameters in idParamString 
        for (Int32 i = 0; i < buildingIDs.Length; i++)
                command.Parameters.Add(new SqlParameter ("@item" + i, buildingIDs[i]));
        command.Parameters.Add(new SqlParameter("@fromDate", startDate);
        // the rest of your code...
    }
