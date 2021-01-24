        IEnumerable<SystemArea> result = (from sa in CurrentContext.systemarea.Include("systemareafunctionality")                                 
                                 select new SystemArea
                                 {
                                     SystemAreaId = sa.SystemAreaId,
                                     SystemAreaCode = sa.SystemAreaCode,
                                     SystemAreaType = sa.SystemAreaType,
                                     SystemAreaDescription = sa.SystemAreaDescription,
                                     SystemAreaCreatedDate = sa.SystemAreaCreatedDate,
                                     SystemAreaUpdateDate = sa.SystemAreaUpdateDate,
                                     SystemAreaStatus = sa.SystemAreaStatus,
                                     Count = sa.systemareafunctionality.Count,
                                     SystemAreaFunctionality = sa.systemareafunctionality.Select(e => new SystemAreaFunctionality { SystemAreaCode =e.SystemAreaCode })
                                 }).ToList();
