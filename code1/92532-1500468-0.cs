    // WCF server side
    public void SaveAllMyObjects(MyObjectCollection objs)
    {
       MyObjectCollection fakeColl = new MyObjectCollection();
       foreach (var oneObj in objs)
       {
           var oneFakeObj = new MyObject();
           oneFakeObj.Id = oneObj.Id;    // Primary key
           // Pretend oneFakeObj was just loaded from the DB
           oneFakeObj.IsNew = False;
           oneFakeObj.IsLoaded = True;
           // Copy all column values
           foreach (var col in MyObject.Schema.Columns)
           {
               oneFakeObj.SetColumnValue(col.ColumnName, oneObj.GetColumnValue(col.ColumnName));
           }
           fakeColl.Add(oneFakeObj);
      }
      fakeColl.SaveAll();
    }
