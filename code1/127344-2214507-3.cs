    // the thread safe way.
    //
    while (true)
    {
        Order orderItem = NULL;
        try { orderItem = queueList.Dequeue(); } catch { break; }
        if (null != OrderItem)
        {
            Save(orderItem);
            Console.WriteLine("Id :{0} Name {1} ", orderItem.Id, orderItem.Name);
        }
    }
