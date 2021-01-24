    foreach(var duplicate in duplicates)
    {
       // write some logic to combine >= 2 Users
       // and remove all but 1 from original Users
       // a rough idea:
       var main = duplicate.First();
       foreach(var user in duplicate.Skip(1))
       {
          // merge user with main
          ....
          toDeleteList.Add(user);
       }
    }
