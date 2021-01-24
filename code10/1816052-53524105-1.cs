    var slotList = list1.Union(list2).OrderBy(s => s.Start);
    Range lastRange = null;
    var rangeList = new List<Range>();
    foreach (Slot slot in slotList)
    {
        if (lastRange == null || slot.Start >= lastRange.End.Value)
        {
            lastRange = new Range(slot);
            rangeList.Add(lastRange);
        }
        else
        {
            lastRange.AddOriginalSlot(slot);
        }
    }
    foreach (var range in rangeList)
        foreach (var slot in range.RecalculatedSlots)
            {
                Console.WriteLine($"Slot {slot.Start} - {slot.End}");
                foreach (Service service in slot.Services)
                    Console.WriteLine($"  Service {service.Id}: {service.Duration}");
            }
    Console.ReadLine();
