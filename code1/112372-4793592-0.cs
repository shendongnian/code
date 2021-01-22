    //data source for Parent Repeater
    var Result = lstGroups.OrderBy(o => o.GroupName).GroupBy(d => d.SiteUrl).Select(s => new { SiteUrl = s.Key, Groups= s });
    
    //On Item Data Bound of Parent Repeater, Bind child repeater
    
    var obj = DataBinder.Eval(e.Item.DataItem, "Groups");
    
    rptChild.DataSource = obj;
    
    rptChild.DataBind();
