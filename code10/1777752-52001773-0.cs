    using (var transaction = context.Database.BeginTransaction())
    {
        try
        {
            foreach (var message in messages)
            {
                var exists = context.Messages.Any(msg => msg.Prop1 == message.Prop1 &&
                                                         msg.Prop2 == message.Prop2 &&
                                                         msg.Prop3 == message.Prop3 &&);
                if (!exists)
                {
                    context.Messages.Add(message);
                }
            }
            context.SaveChanges();
            transaction.Commit();
        }
        catch (Exception ex)
        {
            _logger.Error(ex);
            transaction.Rollback();
            throw;
        }
    }
