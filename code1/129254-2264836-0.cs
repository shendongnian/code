        DAL.ItemCollection coll = new DAL.ItemCollection();
        SubSonic.Select s = new SubSonic.Select();
        s.From(DAL.Item.Schema)
            .Where("Title").Like("%" + q + "%")
            .Or("Tags").Like("%" + q + "%")
            .And("IsActive").IsEqualTo(true);
        if (fid > 0)
        {
            s = s.And("CategoryID").IsEqualTo(fid);
            Session["TotalSearchResults"] = null;
        }
        s = s.Top(maxitems);
        //We'll get the recordcount before paged results
        total = s.GetRecordCount();
        s = s.Paged(pageindex, pagesize);
            .OrderDesc("Hits");
            .OrderDesc("Points");
            .OrderDesc("NumberOfVotes");
        coll = s.ExecuteAsCollection<DAL.ItemCollection>();
