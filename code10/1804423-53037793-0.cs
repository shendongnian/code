    IList<string> List3 = new List<string>();
    foreach (var item1 in List1)
    {
       foreach(var item2 in List3)
       { 
         if (item1 == item2)
         {
            List3.Add(item1);
         }
       }
    }
