    using (var context = new MyEntities())
    {
        Task task = new Task()
        {
            Text = text,
            CreatorId = creator.Id,
            ReceiverId = receiver.Id
        };
        context.Task.Add(task);
        context.SaveChanges();
    }
