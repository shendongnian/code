         var rawDataSet = pDCDataSet.RawData;
            var lastDaysData = from myRow in rawDataSet.AsEnumerable()
                               where myRow.Field<DateTime>("DateTime") > DateTime.Now.AddHours(-Convert.ToInt32(comboBox1.Text))
                               select new
                               {
                                   myRow.DateTime,
                                   myRow.FolderSize,
                                   myRow.FileNumber,
                                   //myRow.Results,
                               };
           var newlist = lastDaysData.ToList();
            DataTable dt = new DataTable();
            dt.Columns.Add("DateTime");
            dt.Columns.Add("FolderSize");
            dt.Columns.Add("FileNumber");
            foreach (var item in newlist)
            {
                var row = dt.NewRow();
                row["DateTime"] = item.DateTime;
                row["FolderSize"] = Convert.ToString(item.FolderSize);
                row["FileNumber"] = item.FileNumber;
                dt.Rows.Add(row);
            }
            dataGridView1.DataSource = dt;
