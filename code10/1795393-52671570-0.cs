    public customer GetCustomer(int cID)
    {
        for (int x = 0; x < numCustomers; x++)
        {
            customer testCustomer = cList[x];
            if (testCustomer.getID() == cusID)
            {
                return testCustomer;
            }
        }
        return null;
    }
