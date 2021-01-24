    using (SqlConnection con = new SqlConnection("Data Source=WIN-M9TBGRD70BU;Initial Catalog=Disk_Tracker;User ID=Tracker;Password=********"))
    {
        using (SqlDataAdapter sda = new SqlDataAdapter("Select * FROM Project_Info WHERE (Project = 'P3890T')", con))
        {
            DataTable dt = new DataTable();
            sda.Fill(dt);
            this.Hide();
            TRACK_10_PI T10 = new TRACK_10_PI(sda);
            T10.Show();
        }
    }
