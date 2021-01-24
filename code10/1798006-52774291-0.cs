    public string getSubGroupData()
    {
        try
        {
            //Label lblGrpName = (Label)rptGroupName.FindControl("lblGrpName");
            lblGrpName.Text = "GrpName";
            var groupname = lblGrpName.Text;
            var v = ViewState["GroupName"];
            List<RootObject> list2 = (List<RootObject>)ViewState["GroupName"];
            List<SubGroup> list1 = new List<SubGroup>();
            var subGroupNames = new HashSet<string>(list2.SelectMany(x => x.SubGroup.Select(y => y.SubGroupName)));
            var result = list1.Where(x => subGroupNames.Contains(x.SubGroupName));
            Repeater2.DataSource = list2;
            Repeater2.DataBind();
        }
    }
