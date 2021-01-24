    else
    {
        lineItem.Quantity = newQuantity;
        int initialCount = lineItem.DelegatesList.Count;
        if (lineItem.DelegatesList.Count > newQuantity)
        {
            for (int i = lineItem.DelegatesList.Count - 1; i >= newQuantity; --i)
            {
                    lineItem.DelegatesList.RemoveAt(i);
            }
        }
        if (lineItem.DelegatesList.Count < newQuantity)
        {
            for (int z = 0; z <= newQuantity - initialCount; z++)
            {
                lineItem.DelegatesList.Add(new OrderDelegate());
            }
        }
        await _basketRepository.SaveAsync();
    }
