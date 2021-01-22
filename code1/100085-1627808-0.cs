    private void MonitorItems()
    {
        if(someCondition)
        {
            dateSelected = DateTime.Now;
            GetAllItems();
        }
        if(allItems.Count>0)
            CheckAllItems();
    }
