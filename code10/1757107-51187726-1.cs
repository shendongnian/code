    using System;
    using System.Data;
    using System.Data.SqlClient;
 
 
    namespace NotifyService
    {
    public class SqlNotifier : IDisposable
    {
        public SqlCommand SqlCmd { get; set; }
        public SqlConnection SqlCon { get; set; }
 
 
        public void StartMonitoring()
        {
            SqlDependency.Start(this.SqlCon.ConnectionString);
            RegisterDependency();
        }
 
 
        private event EventHandler<SqlNotificationEventArgs> _NewNotification;
        public event  EventHandler<SqlNotificationEventArgs> NewNotification
        {
            add { this._NewNotification += value; }
            remove { this._NewNotification -= value; }
        }
 
 
        public virtual void OnNewNotification(SqlNotificationEventArgs notification)
        {  
            if (this._NewNotification != null)
                this._NewNotification(this, notification);
        }
 
 
        public void RegisterDependency()
        {
            this.SqlCmd = new SqlCommand(SqlCmd.CommandText,this.SqlCon);
            this.SqlCmd.Notification = null;
 
 
            SqlDependency dependency = new SqlDependency(this.SqlCmd);
            dependency.OnChange += this.Dependency_OnChange;
 
 
            if (this.SqlCon.State == ConnectionState.Closed)
                this.SqlCon.Open();
 
 
            this.SqlCmd.ExecuteReader();
            this.SqlCon.Close();
        }
 
 
        private void Dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            SqlDependency dependency = (SqlDependency)sender;
            dependency.OnChange -= new OnChangeEventHandler(Dependency_OnChange);
            this.OnNewNotification(e);
            RegisterDependency();
        }
 
 
        public void Dispose()
        {
            SqlDependency.Stop(this.SqlCon.ConnectionString);
        }
 
 
    }
    }
