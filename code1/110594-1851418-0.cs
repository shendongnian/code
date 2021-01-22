            moduleDeviceStates = from ulh in user.UserLoginHistories
                                 join ulcch in userLogin.UserLoginClientConnectionHistories on new { ID = ulh.ID } equals new { ID = ulcch.UserLoginHistoryID }
                                 join cm in clientModuleRepository.GetAll(GenericStatus.Active) on new { ClientModuleID = ulcch.ClientModuleID } equals new { ClientModuleID = cm.ID }
                                 join mo in moduleRepository.GetAll(GenericStatus.Active) on new { ModuleID = cm.ModuleID } equals new { ModuleID = mo.ID }
                                 join m in
                                     (
                                         (from ulcch1 in userLogin.UserLoginClientConnectionHistories
                                          group ulcch1 by new
                                          {
                                              ulcch1.UserLoginHistoryID
                                          } into g
                                          select new
                                          {
                                              maxCreatedAt = g.Max(p => p.CreatedAt)
                                          })) on new { maxCreatedAt = ulcch.CreatedAt } equals new { maxCreatedAt = m.maxCreatedAt }
                                 select new ModuleDeviceState()
                                 {
                                     ModuleID = mo.ID,
                                     Name = mo.Name,
                                     DeviceState = (State.DeviceState)ulcch.DeviceState,
                                     CreatedAt = ulcch.CreatedAt
                                 };
