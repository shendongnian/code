        protected void BindCheckboxes()
        {
            if(!IsPostBack)
    {
    chkBuildings.Items.Clear();
            chkNeighborhoods.Items.Clear();
            string city = ddlFindHome_Location.SelectedItem.Value.ToLower();
            ResidentDataContext rdc = new ResidentDataContext(Utility.Lookup.GetResidentConnectionString());
            var neighs = (from n in rdc.spNeighborhoods where n.vchCity.Equals(city) select n);
            foreach (var neighborhood in neighs)
            {
                ListItem li = new ListItem();
                li.Value = neighborhood.intNeighborhoodID.ToString();
                li.Attributes["onclick"] = string.Format("document.getElementById('{0}').click();", btnNeighHack.ClientID);
                li.Text = neighborhood.vchNeighborhood;
                chkNeighborhoods.Items.Add(li);
            }
            var builds = (from b in rdc.spBuildings
                          join nb in rdc.spNeighborhoodBuildings on b.intBuildingID equals nb.intBuildingID
                          join n in rdc.spNeighborhoods on nb.intNeightborhoodID equals n.intNeighborhoodID
                          where n.vchCity.ToLower().Equals(city)
                          select b).Distinct();
            foreach (var buildings in builds)
            {
                ListItem li = new ListItem();
                li.Value = buildings.intBuildingID.ToString();
                li.Text = buildings.vchName;
                chkBuildings.Items.Add(li);
            }
            upNeighs.Update();
            upBuilds.Update();
    }
        }
