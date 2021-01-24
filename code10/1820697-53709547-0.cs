    var myModels = _dbContext.Models.Include(x => x.Nested).ThenInclude(n => n.FurtherNested).Select(x => new
                {
                    Nested = x.Nested,
                    FurtherNested = x.Nested.First().FurtherNested,
                    FurtherNestedName = x.Nested.First().FurtherNested.Name
                }).ToList();
