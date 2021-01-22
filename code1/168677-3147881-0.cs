    DataTable dt = new DataTable();
            dt.Columns.Add("Want to Delete?",typeof(bool));
            dt.Columns.Add("Data Id", typeof(string));
            dt.Columns.Add("Data 1", typeof(string));
            dt.AcceptChanges();
            return dt;
