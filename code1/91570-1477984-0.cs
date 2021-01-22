    public class MyDataSource : SqlDataSource
    {        
        public MyDataSource()
        {
            if (HttpContext.Current != null)
            {
                this.ConnectionString = MyCinfig.ConnectionString;
                SelectCommandType = SqlDataSourceCommandType.StoredProcedure;
                CancelSelectOnNullParameter = false;
                this.Updated += new SqlDataSourceStatusEventHandler(NXSDataSource_iudExecuted);
                this.Inserted += new SqlDataSourceStatusEventHandler(NXSDataSource_iudExecuted);
                this.Deleted += new SqlDataSourceStatusEventHandler(NXSDataSource_iudExecuted);
            }
        }
    }
