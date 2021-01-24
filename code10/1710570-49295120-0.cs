    using System.Data.OleDb;
    DataTable dt = new DataTable();
    OleDbDataAdapter adapter = new OleDbDataAdapter();
    adapter.Fill(dt, Dts.Variables["User::CoreTables"].Value);
    foreach (DataRow row in dt.Rows)
    {
        //process datatable row here
    }
