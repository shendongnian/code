    IEnumerable<SystemArea> result = (from sa in CurrentContext.systemarea    
                             join systemareafunctionality in CurrentContext.systemareafunctionality on sa.systemareafunctionalityID equals systemareafunctionality.ID into item1 from subitem1 in item1.DefaultIfEmpty() 
                             select new SystemArea
                             {
                                 SystemAreaId = sa.SystemAreaId,
                                 SystemAreaCode = sa.SystemAreaCode,
                                 SystemAreaType = sa.SystemAreaType,
                                 SystemAreaDescription = sa.SystemAreaDescription,
                                 SystemAreaCreatedDate = sa.SystemAreaCreatedDate,
                                 SystemAreaUpdateDate = sa.SystemAreaUpdateDate,
                                 SystemAreaStatus = SystemAreaStatus,
                                 Count = systemareafunctionality.Count,
                                 SystemAreaFunctionality = systemareafunctionality.Select(e => new SystemAreaFunctionality { SystemAreaCode =e.SystemAreaCode })
                             }).ToList();
