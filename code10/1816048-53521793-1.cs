    SlotComparer sc = new SlotComparer();
    var mergedList = list1
        .Union(list2, sc)
        .OrderBy(s => s.Start)
        .ThenBy(s => s.End)
        .ToList();
    foreach (var distinctSlot in mergedList)
    {
        var slotFromList1 = list1.FirstOrDefault(s => sc.Equals(s, distinctSlot));
        var slotFromList2 = list2.FirstOrDefault(s => sc.Equals(s, distinctSlot));
        var services = new List<Service>();
        if (slotFromList1 != null)
            services.AddRange(slotFromList1.Services);
        if (slotFromList2 != null)
            services.AddRange(slotFromList2.Services);
        distinctSlot.Services = services.OrderBy(s => s.Id).ToList();
    }
    return mergedList;
