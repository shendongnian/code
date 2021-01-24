    private void Load_Grid(bool ShouldWeBindToGridView)
    {
     //as first whats the point of calling this method and wasting time reading database 
     //the parameter ShouldWeBindToGridView should be used before this whole method.
      DataSet ds = new DataSet();
      
      //Whenever you can use using USE IT!. it will automatically close connection and dispose.
      using(SqlConnection conn = new SqlConnection(strcnn)){
           conn.Open();
           using(SqlCommand cmd = new SqlCommand("sp_Students", conn)){
             cmd.CommandTimeout = 120;
             cmd.CommandType = CommandType.StoredProcedure;
             using(SqlDataAdapter adapter = new SqlDataAdapter(cmd)){
               adapter.Fill(ds);
             }
         }
      }
      //if(ds != null) does nothing you just made a new dataset it will be never null. Instead check if it contains any tables and any rows
      if(ds.Tables[0] != null)
        if(ds.Tables[0].Rows.Count != 0){
          GridView1.DataSource = ds;
          GridView1.DataBind();
        }else{
          GridView1.DataSource = null;
          GridView1.DataBind();
        }
    }
