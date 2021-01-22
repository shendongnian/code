    <log4net>
        <appender name="AdoNetAppender" type="MyApp.WebAppAdoNetAppender">
        ...
...
    public class WebAppAdoNetAppender : log4net.Appender.AdoNetAppender
    {
        public new string ConnectionString
        {
            get { return base.ConnectionString; }
            set { base.ConnectionString = ...   }
        }
    }
