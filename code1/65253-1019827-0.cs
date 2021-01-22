    MyTypedTableAdapter tableAdapter = new MyTypedTableAdapter();
        MyTypedDataTable dt = tableAdapter.GetData();
        foreach (MyTypedDataRow row in dt.Rows)
        {
            string AptType = row.AppointmentType;
            if (AptType == "FreeTime")
            {
                dt2.ImportRow(row);
            }
        }
        RadGrid2.DataSource = dt2;
