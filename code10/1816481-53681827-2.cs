    var result = (from sa in CurrentContext.systemarea
                              select new SystemArea
                              {
                                  SystemAreaId = sa.SystemAreaId,
                                  SystemAreaType = sa.SystemAreaType,
                                  Count = sa.systemareafunctionality.Count,
                                  SystemAreaFunctionalities = sa.systemareafunctionality.Select(saf => new SystemAreaFunctionality
                                  {
                                      SystemAreaId = saf.SystemAreaId,
                                      SystemAreaFunctionalityController = saf.SystemAreaFunctionalityController,
                                      SystemAreaFunctionalityAction = saf.SystemAreaFunctionalityAction,
                                      SystemAreaFunctionalityType = saf.SystemAreaFunctionalityType,
                                      SystemAreaFunctionalityEmployeeRoleMappings = saf.systemareafunctionalityemployeerolemapping.Select(saferm => new SystemAreaFunctionalityEmployeeRoleMapping
                                      {
                                          SystemAreaFunctionalityEmployeeRoleMappingId = saferm.SystemAreaFunctionalityEmployeeRoleMappingId,
                                          SystemAreaFunctionalityCreatedDate = saferm.SystemAreaFunctionalityCreatedDate
                                      })
                                  })
                              }).ToList();
