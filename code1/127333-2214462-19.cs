    while (queueList.Count > 0)
    {
        Order orderItem = queueList.Dequeue();
        if (!Save(orderItem))
        {
            queueList.Enqueue(orderItem); // Reprocess the failed save, probably want more logic to prevent infinite loop
        }
        else
        {
            Console.WriteLine("Successfully saved: {0} Name {1} ", orderItem.Id, orderItem.Name);
        }
    }
