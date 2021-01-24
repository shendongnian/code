    var query = dbContext.UstMenuler
        .Where(menu => menu.YetkiID == sessionYetkiID)
        .AsEnumerable() // Do the projection in-process
        .Select(menu => new MenuViewModel
                        {
                            UstMenuler = new UstMenuler
                            {
                                ID = menu.ID,
                                Name = menu.Name,
                                YetkiID = menu.YetkiID,
                                ControllerName = menu.ControllerName,
                                ActionName = menu.ActionName
                            }
                        })
        .ToList();
