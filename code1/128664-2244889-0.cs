    public static EntityObject SaveOrUpdate(this EntityObject entity)
    {
        using (MyEntities context = new MyEntities())
        {
            entity.AttachGraph(context, () => new MyEntities());
            context.SaveChanges();
            return entity;
        }
    }
