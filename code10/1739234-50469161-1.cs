      this.context.Screens.Where(x => (x.IsActive == true) && 
                                      (
                                        //Retrieve all Screen designated in RoleScreen
                                        (x.RoleScreens.Any(y => listUserRoleIDs.Any(z => z == y.RoleID))) ||
                                          //Retrieve all Child Screens
                                          ((x.Parent != null)
                                                             //Retrieve all Child Screens that don't have role assignment
                                                             && ((x.RoleScreen == null) || 
                                                             // Retrieve immediate children of the Screen designated in RoleScreen
                                                             // this part will need to be recursed somehow that is difficult if not utterly costly or impossible in classic linq
                                                             ((x.Parent.RoleScreens.Any(y => listUserRoleIDs.Any(z => z == y.RoleID)))
                                                               && (x.IsCheck == false))))
                                      )).ToList();
