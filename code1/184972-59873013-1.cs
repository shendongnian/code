    public class SQLCon
    {
      public static string cs = 
       ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlDataAdapter MyDataAdapter;
        SQLCon cs = new SQLCon();
        DataSet RsUser = new DataSet();
        RsUser = new DataSet();
        using (SqlConnection MyConnection = new SqlConnection(SQLCon.cs))
           {
            MyConnection.Open();
            MyDataAdapter = new SqlDataAdapter("GetAPPID", MyConnection);
            //'Set the command type as StoredProcedure.
            MyDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            RsUser = new DataSet();
            MyDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@organizationID", 
            SqlDbType.Int));
            MyDataAdapter.SelectCommand.Parameters["@organizationID"].Value = TxtID.Text;
            MyDataAdapter.Fill(RsUser, "GetAPPID");
           }
          if (RsUser.Tables[0].Rows.Count > 0) //data was found
          {
            Session["AppID"] = RsUser.Tables[0].Rows[0]["AppID"].ToString();
           }
         else
           {
    
           }    
    }    
