    public string getSubGroupData()
    {
        try
        {
            var groupname = lblGrpName.Text;
            List<RootObject> rootObjects = (List<RootObject>)ViewState["GroupName"];
            //get the rootObjects with the GrpName of lblGrpName.Text
            var filteredRootObjects = rootObjects.Where(x => x.GrpName == groupname);
            //get the subGroup objects of the filteredRootObjects
            var subGroups = filteredRootObjects.SelectMany(x => x.SubGroup);
            //pass the subGroups to your DataSource
            Repeater2.DataSource = subGroups;
            Repeater2.DataBind();
        }
    }
