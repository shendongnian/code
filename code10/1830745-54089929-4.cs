    private DataTable GetGanttTasksSource()
    {
        DataTable dataTable = new DataTable();
        dataTable.Columns.Add(new DataColumn("ID", typeof(int)));
        dataTable.Columns.Add(new DataColumn("ParentID", typeof(int)));
        dataTable.Columns.Add(new DataColumn("OrderID", typeof(int)));
        dataTable.Columns.Add(new DataColumn("Title", typeof(string)));
        dataTable.Columns.Add(new DataColumn("Start", typeof(DateTime)));
        dataTable.Columns.Add(new DataColumn("End", typeof(DateTime)));
        dataTable.Columns.Add(new DataColumn("PercentComplete", typeof(decimal)));
        dataTable.Columns.Add(new DataColumn("Expanded", typeof(bool)));
        dataTable.Columns.Add(new DataColumn("Summary", typeof(bool)));
        dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns["ID"] };
        int parentsCount = 4;
        for (int i = 1; i <= parentsCount; i++)
        {
            DataRow row = dataTable.NewRow();
            row["ID"] = i;
            row["ParentID"] = DBNull.Value;
            row["OrderID"] = i;
            row["Title"] = "Task #" + (i);
            row["Start"] = DateTime.Now.AddDays(i - 1);
            row["End"] = DateTime.Now.AddDays(i);
            row["PercentComplete"] = 0.2M;
            if (i == parentsCount)
            {
                row["Expanded"] = false;
            }
            else
            {
                row["Expanded"] = DBNull.Value;
            }
            row["Summary"] = i == parentsCount; // last task is a parent/summary
            dataTable.Rows.Add(row);
        }
        for (int i = parentsCount + 1; i <= parentsCount + 5; i++)
        {
            DataRow row = dataTable.NewRow();
            row["ID"] = i;
            row["ParentID"] = parentsCount;
            row["OrderID"] = i;
            row["Title"] = "Task #" + (i);
            row["Start"] = DateTime.Now.AddDays(i - 1);
            row["End"] = DateTime.Now.AddDays(i);
            row["PercentComplete"] = 0.4M;
            row["Expanded"] = DBNull.Value;
            row["Summary"] = false;
            dataTable.Rows.Add(row);
        }
        return dataTable;
    }
