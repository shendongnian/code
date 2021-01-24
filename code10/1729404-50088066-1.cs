      list<string> mylist = new list<string>;
      foreach(string item in mylist)
       {
        var letters = new String(item.Where(Char.IsLetter).ToArray());
       }
