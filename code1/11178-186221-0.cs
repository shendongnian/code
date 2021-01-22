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
    ///  modify item
    ///   :
    db.SubmitChanges();
