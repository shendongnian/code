	SqlConnection gconn = new SqlConnection(connection);
	SqlCommand cmd = new SqlCommand("AddCustomerComments", gconn);
    cmd.CommandType = CommandType.StoredProcedure
	SqlParameter surveyIdParam = new SqlParameter("@surveyId", System.Data.SqlDbType.UniqueIdentifier);
	SqlParameter commentParam = new SqlParameter("@comment ", System.Data.SqlDbType.VarChar, 250);
	surveyIdParam.Value = SurveyId;
	commentParam.Value = "This is the comment";
	cmd.Parameters.Add(surveyIdParam);
	cmd.Parameters.Add(commentParam);
