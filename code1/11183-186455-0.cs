    DateTime runUntil = DataTime.Now.Add(timeout);
    forech(Task task in tasks)
    {
       if(DateTime.Now >= runUntil)
       {
            throw new MyException("Timeout");
       }
       Process(task);
    }
