    using System;
    using System.Data;
    using System.Collections;
    using System.Data.Common;
    using System.Data.SqlClient;
    
    namespace TypedDataSet {
    
        public class BaseModel<T> : DataTable {
            protected DbDataAdapter _adapter;
            protected string _connectionString = TypedDataSet.Properties.Settings.Default.ConnectionString;
    
            public BaseModel() {
            }
    
            protected DbDataAdapter Adapter(string sql) {
                _adapter = new System.Data.SqlClient.SqlDataAdapter(sql, _connectionString);
                SqlCommandBuilder cb = new SqlCommandBuilder((SqlDataAdapter)_adapter);
                return _adapter; 
            }
    
            public dynamic this[int index] {
                get { return Rows[index]; }
            }
    
            public void Add(dynamic row) {
                Rows.Add(row);
            }
    
            public void Remove(dynamic row) {
                Rows.Remove(row);
            }
    
            public void Save() {
                _adapter.Update(this);
                this.AcceptChanges();
            }
    
            public dynamic GetNewRow() {
                dynamic row = (dynamic)NewRow();
                return row;
            }
    
            public IEnumerator GetEnumerator() {
                return Rows.GetEnumerator();
            }
    
            protected override Type GetRowType() {
                return typeof(T);
            }
        }
    }
