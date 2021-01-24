    for (int i = Customers.Count - 1; i >= 0; i--)
    {
        Customer item = Customers[i];
        if (item.Customers.ToUpper().Contains(CustomerSearch.ToUpper()) == false)
        {
            Customers.RemoveAt(i);
        }
    }
