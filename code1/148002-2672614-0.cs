    public ActionResult Edit(Item item) 
    {
      Item original = Global.DataContext.Items.Single(x => x.ItemID = item.ItemID); 
      Global.DataContext.Items.Attach(item, original); 
      Global.DataContext.SubmitChanges(); 
     
      return View(item); 
    }
