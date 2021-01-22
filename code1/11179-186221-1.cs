    Item item;
    if (needNewOne)
    {
         item = new Item();
         db.InsertOnSubmit(item);
    }
    else
    {
         item = list[i];
    }
    ///  build new or modify existing item
    ///   :
    db.SubmitChanges();
