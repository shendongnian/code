    void AddGrandparent(int id, ParentFoo pf)
    {
      using (var dc = dcHelper_.CreateDataContext())
      {
        var parent = dc.ParentFoos.Find(pf.Id);
        dc.GrandparentFoos.Add(new GrandparentFoo
        {
          Id = id,
          ParentFoo = parent 
        });
        dc.SaveChanges(); 
      }
    }
