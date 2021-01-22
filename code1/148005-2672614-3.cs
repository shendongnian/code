    public ActionResult Edit(Item item) 
    {
      using(MyDataContext dc = new MyDataContext())
      {
    //this new DataContext has never heard of my item, so I may Attach.
        dc.Items.Attach(item);
    //this loads the database record in behind your changes
    // to allow optimistic concurrency to work.
    //if you turn off the optimistic concurrency in your item class
    // then you won't have to do this
        dc.Refresh(item, KeepCurrentValues);
        dc.SubmitChanges(); 
      }
      return View(item); 
    } 
    public ActionResult Edit(Item item) 
    {
      original = Global.DataContext.Items.Single(x => x.ItemID = item.ItemID)
      //play the changes against the original object.
      original.Property1 = item.Property1;
      original.Property2 = item.Property2;
      Global.DataContext.SubmitChanges(); 
      return View(item); 
    } 
