    con.Open();
    adap = new SqlDataAdapter("SELECT ID, Course_Description as 'Course', Year_Level as 
    'Year Level', Student_Name as 'Name', Classroom as 'Room', Seat_Number as 'Seat No.' 
    from TBL_SeatPlan WHERE Course_Description = '" + cmbCourse.Text + "' and Year_Level 
    = '" + cmbYrLvl.Text + "' ", con);
    DataTable dt = new DataTable();
    adap.Fill(dt);
    dtSeat.DataSource = dt;
    DataGridViewComboBoxColumn Dcolumn = new DataGridViewComboBoxColumn();
    dt.Columns.Add(new DataColumn("Status", typeof(char)));
    Dcolumn.HeaderText = "Status";
    Dcolumn.Items.Add("Absent");
    Dcolumn.Items.Add("Present");
    
    con.Close();
