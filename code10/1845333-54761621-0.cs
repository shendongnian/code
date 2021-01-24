    using (SqlConnection con = new SqlConnection(dc.Con)) {
       using (SqlCommand cmd = new SqlCommand("CreateLeavePrerequest", con)) {
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.Parameters.Add("@LeaveType", SqlDbType.VarChar).Value = leaveType;
           cmd.Parameters.Add("@StartDate", SqlDbType.VarChar).Value = startDate;
           cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = endDate;
           cmd.Parameters.Add("@NumberOfDays", SqlDbType.VarChar).Value = numberOfDays;
           cmd.Parameters.Add("@EmployeeComment", SqlDbType.VarChar).Value = employeeComment;
           cmd.Parameters.Add("@SickNoteIndicator", SqlDbType.VarChar).Value = sickNoteIndicator;
           cmd.Parameters.Add("@ResourceTag", SqlDbType.VarChar).Value = resourceTag;
           cmd.Parameters.Add("@RemainingBalance", SqlDbType.VarChar).Value = remainingBalance;
           cmd.Parameters.Add("@ApproverResourceTag", SqlDbType.VarChar).Value = approverResourceTag;
           cmd.Parameters.Add("@CapturerResourceTag", SqlDbType.VarChar).Value = capturerResourceTag;
           cmd.Parameters.Add("@SupportingDocumentID", SqlDbType.VarChar).Value = supportingDocumentID;
           cmd.Parameters["@id"].Direction = ParameterDirection.Output; 
        
           con.Open();
           cmd.ExecuteNonQuery();
      }
    }
