    if (dt.Rows.Count > 0)
    {
        DateTime baseTime = DateTime.Parse("09:45:00");
        dt.Columns.Add("PA", typeof(System.String)); //If this column already exists, just use the code from below to add value to it, and skip this row
        foreach(DataRow row in dt.Rows)
        {
           DateTime t = DateTime.Parse(row[6].ToString()); //Your column 6 has Time, as visible from your code
           if(t<=baseTime)
              row["PA"] = "PRESENT";
            else
              row["PA"] = "ABSENT";            
            string txt = "Update attendance set pa = @value where attendance_id = @id";
            SqlCommand cmd = new SqlCommand("txt", ConnectionString.Getconnection());
            cmd.Parameters.AddWithValue("@value", row[PA]);
            cmd.Parameters.AddWithValue("@id", row[9]); //column 9 is attendance id
            cmd.ExecuteNonQuery();
        }
       dataGridView1.DataSource = dt;
       dataGridView1.Columns[0].HeaderText = "Code";
       dataGridView1.Columns[1].HeaderText = "Name";
       dataGridView1.Columns[2].HeaderText = "Department";
       dataGridView1.Columns[3].HeaderText = "Year";
       dataGridView1.Columns[4].HeaderText = "Month";
       dataGridView1.Columns[5].HeaderText = "Day";
       dataGridView1.Columns[6].HeaderText = "Time";
       dataGridView1.Columns[7].HeaderText = "Status";
       dataGridView1.Columns[8].HeaderText = "EMP/MACH-CODE";  
       dataGridView1.Columns[9].HeaderText = "Attendance_id";
       dataGridView1.Columns[9].Visible = false;
       dataGridView1.Columns[10].HeaderText = "P/A";
       // dataGridView1.Columns["Attendance_id"].Visible = false;
        dataGridView1.AllowUserToAddRows = false;
        dataGridView1.AllowUserToResizeColumns = false;
        dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
        this.dataGridView1.DefaultCellStyle.BackColor = Color.GhostWhite;
      }
