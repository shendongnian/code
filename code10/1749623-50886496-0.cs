    for (i = 0; i < length+1; i++)
    {
        DataWayPoints.Rows.Add();
        
        DataWayPoints["Waypoint", i].Value = Convert.ToString(i + 1);
        DataGridViewComboBoxCell CommandCell = (DataGridViewComboBoxCell)(DataWayPoints["MAVLnkCmd", i]);
        CommandCell.Value = dsRoute.Tables[i].Rows[0]["MAVLnkCmd"].ToString();
        DataWayPoints["P1", i].Value = dsRoute.Tables[i].Rows[0]["P1"].ToString();
        DataWayPoints["P2", i].Value = dsRoute.Tables[i].Rows[0]["P2"].ToString();
        DataWayPoints["P3", i].Value = dsRoute.Tables[i].Rows[0]["P3"].ToString();
        DataWayPoints["P4", i].Value = dsRoute.Tables[i].Rows[0]["P4"].ToString();
        DataWayPoints["Latitude", i].Value = dsRoute.Tables[i].Rows[0]["Latitude"].ToString();
        DataWayPoints["Longitude", i].Value = dsRoute.Tables[i].Rows[0]["Longitude"].ToString();
        DataWayPoints["Altitude", i].Value = dsRoute.Tables[i].Rows[0]["Altitude"].ToString();
        DataWayPoints["DistanceToNextWpt", i].Value = dsRoute.Tables[i].Rows[0]["DistanceToNextWpt"].ToString();
        DataWayPoints["Velocity", i].Value = dsRoute.Tables[i].Rows[0]["Velocity"].ToString();
    }
