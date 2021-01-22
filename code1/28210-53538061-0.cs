    public ActionResult ListMyItems(int page)
    {
       List<Item> list = ItemDB.GetListOfItems();
       int pageSize = 3;
       int pageNumber = (page ?? 1);
       return View(list.ToPagedList(pageNumber, pageSize));
    }
