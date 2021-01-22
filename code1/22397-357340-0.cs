    using(var db = new ItemMasterDataContext())
    {
        var s = txtSearch.Text.Trim();
        var result = from p in db.ITMSTs select p;
        
        if( result.Any(p=>p.IMITD1.Contains(s))
             lv.DataSource = result.Where(p=>p.IMITD1.Contains(s))
        else if ( result.Any(p=>p.IMITD2.Contains(s))
            lv.DataSource = result.Where(p=>p.IMITD1.Contains(s))
            
        lv.DataBind();
    }
