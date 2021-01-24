    var myModels = _dbContext.Models.Include(x => x.Nested).ThenInclude(n => n.FurtherNested).Select(x => new
                {
                    Nested = x.Nested.Select(n => new
                    {
                        FurtherNestedId = n.FurtherNestedId,
                        FurtherNested = n.FurtherNested
                    })
                    
                }).ToList();
