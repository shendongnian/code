    using System.Collections.Generic;
    using System.Data.OleDb;
            List<DuplicateDeviceModel> lstduplicateDevices = new List<DuplicateDeviceModel>();
            DataTable dt = new DataTable();
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            adapter.Fill(dt, Dts.Variables["User::DuplicateDevices"].Value);
            foreach (DataRow dr in dt.Rows)
               {
                //convert columns from data type to data types of list as necessary
                lstduplicateDevices.Add(new DuplicateDeviceModel() { 
                ColumnA = Convert.ToInt32(dr[0]),
                ColumnB = dr[1].ToString() });
                }
