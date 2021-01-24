    var gpq = (
       from spg in session.Query<Table1>()
       join spgm in session.Query<Table2>() on spg.Table1Key equals spgm.Table2Key 
	   join sp in session.Query<Table3>() on spgm.Table2ID equals sp.Table3ID 
       orderby spg.Table1ID
       select spg
    ).Distinct();
	
    var groups = gpq.Timeout(120).ToList();
