    var result = db.TBL_AssocIncidentSpecialCat
                    .Join(
                        db.TBL_SpecialCategories,
                        ais => new { Id = ais.IncidentId },
                        sc => new { Id = sc.Id },
                        (ais, sc) => { return sc; }
                    )
                    .ToList();
