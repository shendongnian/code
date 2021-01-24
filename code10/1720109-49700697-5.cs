    public ActionResult Name()
    {
         ***
         List<SelectListItem> Items = Model.GetItemList();
         var myViewModel = new MyViewModel { Items = Items }
         return View("Name", myViewModel);
    }
