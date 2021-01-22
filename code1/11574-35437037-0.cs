    using(var ctx = new LinqDataContext())
    {
        List<Task> tasks = new List<Task>();
        for(int i=0;i<1000;i++)
        {
            var task = Task.Run(() => {
                var customer = ctx.Customers.SingleOrDefault(o => o.Id == i);
                customer.DoSomething();
            }
            tasks.Add(task);
        }
        Task.WaitAll(tasks);
    }
