    var found = viewModel.menuSubMenuTreeList
                         .Where(x => x.SubMenus.Where(y => y.MenuID == subMenuId).Any())
                         .FirstOrDefault();
    
    var objectToUpdate = found != null ? found.SubMenus.Where(y => y.MenuID == subMenuId) : null;
