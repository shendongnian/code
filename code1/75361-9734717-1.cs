    using System;
    using System.Data.SqlClient;
    using System.Reflection;
    
    namespace CSP
    {
        public class TableAdapterBase : System.ComponentModel.Component
        {
            public TableAdapterBase()
            {
                SetCommandTimeout(GetConnection().ConnectionTimeout);
            }
    
            public void SetCommandTimeout(int Timeout)
            {
                foreach (var c in SelectCommand())
                    c.CommandTimeout = Timeout;
            }
    
            private System.Data.SqlClient.SqlConnection GetConnection()
            {
                return GetProperty("Connection") as System.Data.SqlClient.SqlConnection;
            }
    
            private SqlCommand[] SelectCommand()
            {
                return GetProperty("CommandCollection") as SqlCommand[];
            }
    
            private Object GetProperty(String s)
            {
                return this.GetType().GetProperty(s, BindingFlags.NonPublic | BindingFlags.GetProperty | BindingFlags.Instance).GetValue(this, null);
            }
        }
    }
