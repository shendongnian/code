    public ActionResult Name()
    {
         ***
         List<SelectListItem> Items = Model.GetItemList();
         return View(Items);
    }
