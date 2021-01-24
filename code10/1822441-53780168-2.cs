    var DadAPIResponse = _context.Dads
                .Where(o.Id == Id)
                .Select(d => new DadModel{
                    Id = d.Id,
                    Name = d.Name
                    Kids = d.Kids.Select(k => new KidsModel
                    {
                        Id = k.Id,
                        Name = k.Name
                    }).Tolist()
                }).AsNoTracking()
                .FirstOrDefault();
