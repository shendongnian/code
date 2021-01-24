    return db.Partenaires
                .Where(p => p.PartenairePrestations.Any(pp => pp.Prestation.NomPrestation == prestation.Value))
                .AsEnumerable()
                .Select(p => new PartenaireMapItem {
                    IdPartenaire = p.IdPartenaire,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    NomComplet = p.LastName.Substring(0,1).ToUpper() + ". " + p.FirstName,
                    Type = p.Type,
                    DureeMin = 50,
                    Lat = p.Lat,
                    Lng = p.Lng,
                    ImageUrl = p.ImageUrl,
                    SeDeplace = p.SeDeplace,
                    ADomicile = p.ADomicile,
                    NoteGlobale = p.NoteClientPartenaires.Sum(x => ((double)(x.NoteAimabilite + x.NotePonctualite +
                                             x.NoteProprete + x.NoteQualite)) / 4) / p.NoteClientPartenaires.Count,
                    Prestations = new List<string>(p.PartenairePrestations.Select(y => y.Prestation.NomPrestation))
                }).ToList();
