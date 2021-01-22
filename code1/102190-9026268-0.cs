    public void Populate_DriverDropDown()
        {
            //Opening and closing connection not required while using SqlDataAdapter 
    
            //sql command to select the drivers and their ids (displaying both the drivername and firstSurname)
            String sqlQuery = "SELECT driverID, nameDriver+' '+firstSurname AS driverFullname FROM driver ORDER BY driverID ASC";
            //end
            
            //using SqlDataAdapter and DataSet
           SqlDataAdapter Da = new SqlDataAdapter(sqlQuery, DBConn);
    
            DataSet Ds = new DataSet();
    
            Da.Fill(Ds, "driver");
    
            if (Ds.Tables[0].Rows.Count > 0)
            {
                //populating each dropdown row with driver name and id.
                foreach (DataRow Dr in Ds.Tables[0].Rows)
                {
                    VehicleDriver.Items.Add(new ListItem(Dr["driverFullname"].ToString(), Dr["driverID"].ToString()));
                }
            }
    
            //to have select option at the top of the dropdown list
            VehicleDriver.Items.Insert(0, "Select a driver");
            
        }
