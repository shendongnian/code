    List<BanquetMenuType> listMenu = new List<BanquetMenuType>();
    listMenu = wsobj.GetOrdermenuTypeByOid(OrderID);
    
    for (int i = 0; i < listMenu.Count; i++)
    {
        listMenu[i].data = wsobj.GetOrderMenuById(listMenu[i].OrderID, listMenu[i].MenuId);
    }
    outerGrid.DataSource = listMenu;
    outerGrid.DataBind();
