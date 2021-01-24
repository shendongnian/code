    select new MenuViewModel
    {
        UstMenuler = new UstMenuler
        {
            ID = menu.ID,
            Name = menu.Name,
            YetkiID = menu.YetkiID,
            ControllerName = menu.ControllerName,
            ActionName = menu.ActionName
        }
    }
