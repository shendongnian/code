    int i;
    if (int.TryParse(theOrder.OrderData, out i))
    {
        if (i < 10000)
        {
           // Do stuff...
        }
    }
