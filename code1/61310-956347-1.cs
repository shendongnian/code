     List<ListType> newLst2 = list2.ToList();
        
        Array.ForEach(list1.ToArray(), list1It =>
        {
           var isInList2 = from list2it in newLst2.ToArray()
                           where (string)list2it.Id == list1It.Id
                           select list2it;
            
           if (isInList2.Count() == 0)
               newLst2.Add(new ListType { Id = list1It.Id, Name = list1It.Name });
               
        });     
