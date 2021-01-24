    var allItems = getMyTop50();
    var topPriorityItems = list.Where(x => x.flag == 1).ToList();
    var topNonPriorityItems = list.Where(x => x.flag != 1).ToList();
    
    var result = topNonPriorityItems
        .Take(constant)
        .Concat(topPriorityItems)
        .Concat(topNonPriorityItems.Skip(constant));
