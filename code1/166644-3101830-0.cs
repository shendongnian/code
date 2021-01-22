    if (Badge != String.Empty)
        {
            string cmdquery = "SELECT * from Employees WHERE Badge ='" + Badge + "'";
            string hrquery = "SELECT CLOCK_IN_TIME, CLOCK_OUT_TIME FROM CLOCK_HISTORY   WHERE Badge ='" + Badge + "'";
            OracleCommand cmd = new OracleCommand(cmdquery);
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            conn.Open();
            OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    this.xUserNameLabel.Text += reader["EMPLOYEE_NAME"];
                    this.xDepartmentLabel.Text += reader["REPORT_DEPARTMENT"];
                }
                OracleCommand Hr = new OracleCommand(hrquery);
                Hr.Connection = conn;
                Hr.CommandType = CommandType.Text;
                OracleDataReader read = Hr.ExecuteReader();
                //What's this next line? Setting the datasource automatically
                // moves through the data.
                //while (read.Read())
                //{
                                              //I changed this to "read", which is the
                                              //datareader you just created.
                    xHoursGridView.DataSource = read;
                    xHoursGridView.DataBind();
                //}
        }
        conn.Close();
