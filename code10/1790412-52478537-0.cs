    foreach (var item in resultparsed.result.items)
    {
        var existingItem = MyConceptItems.FirstOrDefault(x => x.DateColumn == item.entryDate);
        if(existingItem != null)
        {
            //update properties...
        }
        else
        {
            //add new item
            MyConceptItems.Add(new MyDataConcept(item.entryDate, item.entryDayName,
                item.projectName, item.activityName, item.formattedDuration);
        }
    }
