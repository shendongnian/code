    var tempList = new ObservableCollection<ServiceItem>();
    tempList = ServiceList;
    var targetItem = from item in tempList
        where item.UniqueId == uniqueId
        select item;
    if (targetItem.Any())
    {
        var resultItem = targetItem.FirstOrDefault();
        resultItem.CanStatusVisible = true;
        resultItem.OperationStatus = string.Format("{0}: {1}", "Status Message", resultMessage);
    }
    ServiceList.Clear();
    ServiceList = tempList;
