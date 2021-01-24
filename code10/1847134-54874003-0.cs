        using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MfgDataCollector"].ToString()))
        {
            List<Zone> Zonelist = conn.Query<Zone>("GetZone", commandType: CommandType.StoredProcedure).ToList<Zone>();
            
            Zonelist.Insert(0, new Zone() { ZoneID = -1 , ZoneName = "Select one..." });
            CB_Zones.DataSource = Zonelist;
            CB_Zones.DisplayMember = "ZoneName";
            CB_Zones.ValueMember = "ZoneID";
            CB_Zones.Text = "";
        }
    
