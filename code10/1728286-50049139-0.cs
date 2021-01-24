    var data = DbContext.MyClass.Where(del);                        
                                .Join(DbContext.Detail,
                                      mc => mc.Id,
                                      detail => detail.Id,
                                      (m, d) => new { m, d }
                                 );
