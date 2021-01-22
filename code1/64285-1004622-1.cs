    // Populate repeater
    SqlParameter[] paramz = new SqlParameter[1];
    paramz[0] = new SqlParameter("@c_id", 1);
    dt = SqlHelper.ExecuteDataTable(ConfigurationManager.ConnectionStrings["sql"].ToString(), CommandType.StoredProcedure, "get_Questions", paramz);
    repData.DataSource = dt;
    repData.DataBind();
