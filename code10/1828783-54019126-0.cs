    var result = relationDTOList
                    .Where(v => v.PersonId < v.RelativeId)
                    .GroupJoin(relationDTOList,
                               p => p.PersonId,
                               a => a.RelativeId,
                               (p, al) =>
                                    new{
                                        p.PersonId,
                                        p.RelativeId,
                                        p.Relation,
                                        ReverseRelation = al.Where( x => 
                                                  x.PersonId == p.RelativeId &&
                                                  x.RelativeId == p.PersonId )
                                                    .SingleOrDefault()
                                                    .Relation} ).ToList();
