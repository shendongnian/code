    protected void ds_Updating(object sender, SqlDataSourceCommandEventArgs e)
    { 
      //override what was set in the aspx
      var p = e.Command.Parameters["@ts"];
      p.DbType = Binary;
      p.Direction = ParameterDirection.InputOutput;
      p.Size = 8;
      var ts = (System.Data.Linq.Binary)Session["MyTable_ts"];
      p.Value = ts.ToArray();  //Binary must be cast to an Array (of Byte)
    }
