    var query = relationDTOList.OrderBy(x=>x.PersonId).GroupJoin(relationDTOList,
    p => p.PersonId,
    a => a.RelativeId,
    (p, al) =>
    new
    {
         p.PersonId,
         p.RelativeId,
         p.Relation,
         Parrent = al.Where(x => x.PersonId == p.RelativeId && x.RelativeId == p.PersonId).SingleOrDefault().Relation
     }
     ).ToList();
