    public void FillGrid1(bool IsSearching = false)
    {
    if (IsSearching && !string.IsNullOrEmpty(TxbSearch.Text.Trim()))
    {
        var prsCode = from p in db.Prs
                      join pd in db.PDPs on p.ID equals pd.PrsID
                      where p.PrsCode.StartsWith(TxbSearch.Text.Trim())
                      select p;
        var prsLname = from p in db.Prs
                       join pd in db.PDPs on p.ID equals pd.PrsID
                       where p.Lname.Contains(TxbSearch.Text.Trim())
                       select p;
        if (prsCode.Count() > 0)
        {
            DG_PDP.DataSource = from p in db.Prs
                                join pd in db.PDPs on p.ID equals pd.PrsID
                                where p.PrsCode.StartsWith(TxbSearch.Text.Trim())
                                select p;
        }
        else if (prsLname.Count() > 0)
        {
            DG_PDP.DataSource = from p in db.Prs
                                join pd in db.PDPs on p.ID equals pd.PrsID
                                where p.Lname.Contains(TxbSearch.Text.Trim())
                                select p;
        }
        else// it means no match has been found
        {
            //DG_PDP.DataSource = null;
            DG_PDP.DataSource = from p in db.Prs
                                join pd in db.PDPs on p.ID equals pd.PrsID
                                where p.id==0 // I know that there is no such an ID
                                select p;
        }
    }
    else
    {
        DG_PDP.DataSource = from p in db.Prs
                            join pd in db.PDPs on p.ID equals pd.PrsID
                            join ep in db.ExecutivePosts on pd.ExePID equals ep.ID
                            join pr in db.PDP_Priorities on pd.PriorityID equals pr.ID
                            join ps in db.PDP_Satisfactions on pd.SatisfactionID equals ps.ID
                            join s in db.SubCrts on pd.SubCrtID equals s.ID
                            select p;
    }
