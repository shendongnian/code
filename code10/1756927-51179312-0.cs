    public IEnumerable<MyList> LoadData()
    {
        var ctx = new DbContext();
        var set = ctx.tblTimes.AsQueryable();
       if(DataFrom.Checked && DataTo.Checked)
       {
           DateTime inicio = DataAgendFrom.Value;
           DateTime fim = DataAgendTo.Value;
           set = set.Where(s => s.Data >= inicio && s.Data <= fim);
        }
        var query = (from t in set.Where(s => s.Included == true)
                     join av in ctx.tblPrincipal on t.AID equals av.AID
                     join c in ctx.tblCon on av.ConID equals c.ConID
                     join e in ctx.tblEnt on av.EntID equals e.EntID
                     group t by new
                     {
                         c.Name,
                         e.Entity
                     } into grp
                     select new MyList
                     {
                         Con = grp.Key.Name,
                         Ent = grp.Key.Entity,
                         Count = grp.Count(),
                         Med = grp.Average(s => s.Time),
                         Data = grp.Select(s => s.tblPrincipal.Data).FirstOrDefault()
                     });
        if (CmbCon.SelectedItem != null)
        {
            var selected = (tblCon)CmbCon.SelectedItem;
            query = query.Where(s => s.Name == selected.Name);
        }
        if (CmbEnt.SelectedItem != null)
        {
            var selected = (tblEnt)CmbEnt.SelectedItem;
            query = query.Where(s => s.Entity == selected.Entity);
        }
      
        return query.ToList();
    }
