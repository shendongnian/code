    List<VwBusinessUnits> businessUnits = db.VwBusinessUnits
                                          .Where( y => (
                                                         db.VwBusinessUnits
                                                         .Where(x => x.StateOrProvince== "QLD")
                                                         .OrderBy(x => x.BusinessUnitName)                                         
                                                         .Select(x=>x.BusinessUnitName)
    								                     .Distinct()
    								                     .Take(take)
    						                           ).Contains(y.BusinessUnitName)
    					                         ).ToList()
