    select new MenuViewModel
    {
        menuler.UstMenuler.ID = menu.ID,
        menuler.UstMenuler.Name = menu.Name,
        menuler.UstMenuler.YetkiID = menu.YetkiID,
        menuler.UstMenuler.ControllerName = menu.ControllerName,
        menuler.UstMenuler.ActionName = menu.ActionName
    }
