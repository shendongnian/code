    protected void ObjectDataSource_Selected(object sender,
    ObjectDataSourceStatusEventArgs e)
    {
          //If ReturnValue is a DataTable - you might need to change this in your case.
          DataTable dt = (DataTable)e.ReturnValue;
          Response.Write(dt.Rows.Count.ToString());
     }
