        private void DataGrid1_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            DataTable dt = new DataTable();
            DataRowView row = (DataRowView)dataGrid1.SelectedItems[0];
            string barcode_string = row["BarCode"].ToString();
            //string barcode_detail = "SELECT BarCode, PCBGUID FROM TB_AOIResult WHERE BarCode = '" + barcode_string + "'";
            string barcode_detail = "SELECT BarCode, PCBGUID FROM TB_AOIResult WHERE BarCode = @BarCode;";
            using (SqlConnection cn = new SqlConnection("Your connection string")) 
            {
                SqlCommand cmd = new SqlCommand(barcode_detail, cn);
                cmd.Parameters.Add("@BarCode", System.Data.SqlDbType.VarChar).Value = barcode_string;
                cn.Open();
                dt.Load(cmd.ExecuteReader());
                //use the data in the data table
            }
        }
