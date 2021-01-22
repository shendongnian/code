    var e = some_entity;
    
    var cs = dc.GetChangeSet();
    
    if (cs.Inserts.Any( x => x == e))
    {
      dc.SomeTable.DeleteOnSubmit(e);
    }
    
    dc.SubmitChanges();
