    namespace xxx.DsXxxTableAdapters {
        partial class ZzzTableAdapter
        {
            public void SetTimeout(int timeout)
            {
                if (this.Adapter.DeleteCommand != null) { this.Adapter.DeleteCommand.CommandTimeout = timeout; }
                if (this.Adapter.InsertCommand != null) { this.Adapter.InsertCommand.CommandTimeout = timeout; }
                if (this.Adapter.UpdateCommand != null) { this.Adapter.UpdateCommand.CommandTimeout = timeout; }
                if (this._commandCollection == null) { this.InitCommandCollection(); }
                if (this._commandCollection != null)
                {
                    foreach (System.Data.SqlClient.SqlCommand item in this._commandCollection)
                    {
                        if (item != null)
                        { item.CommandTimeout = timeout; }
                    }
                }
            }
        }
     
        //....
     
     }
