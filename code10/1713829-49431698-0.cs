    foreach (DataTable table in result.Tables)
    {
        bool skippedRow = false;
        foreach (DataRow dr in table.Rows)
        {
            if (!skippedRow)
            {
                skippedRow = true;
                continue;
            }
            Employee addtable = new Employee()
            {
                Serial = Convert.ToInt32(dr[0]),
                Name = Convert.ToString(dr[1]),
                Class = Convert.ToString(dr[2]),
                Department = Convert.ToString(dr[3]),
                Status = Convert.ToString(dr[4]),
                Position = Convert.ToString(dr[5]),
                Email = Convert.ToString(dr[6])
            };
            conn.Employees.InsertOnSubmit(addtable);
        }
    }
