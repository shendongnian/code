     IQueryable<object> result;
     if (area == "dashboard")
                            {
                                result = (from m in _entities.ViewGetNavigationMainItems
                                          where m.area.Trim() == area.Trim()
                                          && m.state == "Online"
                                          && m.parentID == parentID
                                          orderby m.sequence ascending
                                          select m);  
                            }
                            else
                            {
                                //Get the Content Items
                                result = (from m in _entities.ViewGetNavigationContentItems
                                          where m.navID == navID
                                          && m.parentID == parentID
                                          orderby m.contentOrder ascending
                                          select m);
                            }
