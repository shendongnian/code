    lstDeliveryDetails.Clear();
    for (int i = 0; i < myDeliveries.Count; i++)
    {
        Delivery d = (Delivery)mainForm.myDeliveries[i];
        if (d.DeliveryName == searchValue)
             lstDeliveryDetails.Items.Add(d.DeliveryName);
    }
