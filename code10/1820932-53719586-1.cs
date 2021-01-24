    var list1 = listVariable.OrderBy(x=>x.TimeStamp).Where(x => x.Timestamp >= 
                                             StartDateTime.LocalDateTime && x.Timestamp < 
                                             EndDateTime.LocalDateTime).ToList();
    var minItem = list1.Min(x=>x.TimeStamp);
    var list2 = listVariable.Where(x.Timestamp < minItem.LocalDateTime).OrderBy(x=>x.TimeStamp).First();
    var finalList = list.Concat(list2);
