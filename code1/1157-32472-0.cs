    protected void LdsPostings_Selecting(object sender, LinqDataSourceSelectEventArgs e)
    {   
        var dc = new MyDataContext();
        var query = dc.Posting.AsQueryable();
        
        if (isCondition1)
        {
            query = query.Where(q => q.PostedBy == Username);
            e.Result = QueryProjection(query);
            return;
        }
        
        ...
        
        if (isConditionN)
        {
            query = query.Where(q => q.Status.StatusName == "submitted");
            query = query.Where(q => q.ReviewedBy == Username);
            e.Result = QueryProjection(query);
            return;
        }
    }
