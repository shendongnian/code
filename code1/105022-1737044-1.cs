        var baseQuery = from c in _lookUpTableValuesRepository
                                   .GetAllRowsWhere(l => l.ParentID == filter 
                                                    && l.IsActive==true)
                     select new BaseTable { ID = c.ID, 
                                            Description = c.Description,
                                            ParentID = c.ParentID };
        var converted = baseQuery.AsEnumerable()
                                 .Select(b => new T() { ID = b.ID, 
                                                        Description = b.Description,
                                                        ParentID = b.ParentID };
