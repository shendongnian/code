    public string getSubGroupData()
    {
        try
        {
            var groupname = lblGrpName.Text;
            List<RootObject> rootObjects = (List<RootObject>)ViewState["GroupName"];
            //get the first entry in rootObjects with the GrpName of lblGrpName.Text
            var rootObject = rootObjects.First(x => x.GrpName == groupname);
            //pass the List<SubGroup> member SubGroup of the found RootObject
            Repeater2.DataSource = rootObject.SubGroup;
            Repeater2.DataBind();
        }
    }
