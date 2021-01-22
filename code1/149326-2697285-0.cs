    foreach (var group in groupedCustomerList)
    {
        Console.WriteLine("Group {0}", group.Key);
        foreach (var user in group)
        {
            Console.WriteLine("  {0}", user.UserName);
        }
    }
